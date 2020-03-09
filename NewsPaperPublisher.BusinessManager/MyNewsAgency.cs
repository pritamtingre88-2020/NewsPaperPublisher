using NewsPaperPublisher.BusinessManager.NewsSource;
using NewsPaperPublisher.Entities;
using NewsPaperPublisher.SampleRepos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NewsPaperPublisher.BusinessManager
{
    //This is the actual business logic class which performs the business logic of compiling news paper
    public class MyNewsAgency : ISubscriber
    {
        //The news agency has News source(for the sake of demo there's just one, however, could be multiple)
        //Different implementations of News source could be injected at run time via depndency injection.
        //e.g. In unit tests, we could inject a faked/mocked datasource.
        INewsSource NewsSource { get; set; }

        List<News> NewsItems = new List<News>();

        string subscriberId { get; set; }

        const int maxPageLimit = 8;
        public MyNewsAgency(INewsSource newsSources)
        {
            this.NewsSource = newsSources;
            subscriberId = NewsSource.Register(this);
        }

        public NewsPaper CompileNewsPaper()
        {
            //Step 1. Fetch all the news from the news source.(This demos the pull mode of the publis-subscribe/observable pattern)
            var newsItems = NewsSource.FetchNews(subscriberId).OrderBy(n => n.Priority);
            NewsItems.AddRange(newsItems);
            //Step 1.1 Fetch all the ads
            var adds = AdvertisementRepository.GetAdds().ToArray();

            //Step 2. Start Compiling newspaper for the fetched news and ads
            var newsPaper = new NewsPaper
            {
                Name = "The News Express",
                Date = DateTime.Now.Date
            };
            Page page = null;
            int advertisementEnumerator = 0;
            foreach (var news in NewsItems)
            {
                if (page == null || (page.NewsArticles.Count + page.Advertisements.Count == maxPageLimit))
                {
                    page = new Page();
                    if (newsPaper.Pages == null)
                        newsPaper.Pages = new List<Page>();
                    newsPaper.Pages.Add(page);
                }
                if (page.NewsArticles.Count < 6)
                {
                    page.NewsArticles.Add(news);
                }
                else if(advertisementEnumerator < adds.Count())
                {
                    page.Advertisements.Add(adds[advertisementEnumerator]);
                    advertisementEnumerator++;
                }
            }
            //There are still some adds to be placed on the pages
            if(advertisementEnumerator < adds.Count())
            {
                var lastPage = newsPaper.Pages.LastOrDefault();
                while(advertisementEnumerator < adds.Count())
                {
                    if (lastPage.NewsArticles.Count + lastPage.Advertisements.Count < maxPageLimit)
                    {
                        lastPage.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                }
            }
            return newsPaper;
        }

        //This is to demo Push model of the publisher-subscriber/observable pattern.
        //Whenever the news source publishes a news, the subscriber will receive the news.
        void ISubscriber.ReceiveNews(News newNews)
        {
            NewsItems.Add(newNews);
        }
    }
}
