using NewsPaperPublisher.BusinessManager.AdvertisementSource;
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

        IAdvertisementSource AdvertisementSource { get; set; }

        List<News> NewsItems = new List<News>();

        string subscriberId { get; set; }

        const int maxPageLimit = 8;
        const int maxNewsItemsOnPage = 6;
        public MyNewsAgency(INewsSource newsSources, IAdvertisementSource advertisementSource)
        {
            NewsSource = newsSources;
            AdvertisementSource = advertisementSource;
            subscriberId = NewsSource.Register(this);
        }

        public NewsPaper CompileNewsPaper()
        {
            //Step 1. Fetch all the news from the news source.(This demos the pull mode of the publis-subscribe/observable pattern)
            var newsItems = NewsSource.FetchNews(subscriberId);
            if (newsItems == null || newsItems.Count() <= 0)
            {
                throw new Exception("No news items returned from the news source");
            }
            NewsItems.AddRange(newsItems.OrderBy(n => n.Priority));
            //Step 1.1 Fetch all the ads
            var adds = AdvertisementSource.GetAdds().ToArray();

            //Step 2. Start Compiling newspaper for the fetched news and ads
            var newsPaper = new NewsPaper
            {
                Name = "The News Express",
                Date = DateTime.Now.Date,
                Pages = new List<Page>()
            };
            Page page = new Page();
            newsPaper.Pages.Add(page);
            int advertisementEnumerator = 0;
            foreach (var news in NewsItems)
            {
                if (IsPageFull(page))
                {
                    page = new Page();                    
                    newsPaper.Pages.Add(page);
                }
                if (page.NewsArticles.Count < maxNewsItemsOnPage)
                {
                    page.NewsArticles.Add(news);
                }
                else //max news items added to page, now we can accomodate advertisements
                {
                    //Keep adding advertisements to the page till page is full
                    while (!IsPageFull(page) && advertisementEnumerator < adds.Count())
                    {
                        page.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                    //Create new page if after adding advertisements, the page is full, else add news to the same page
                    if (IsPageFull(page))
                    {
                        page = new Page();
                        newsPaper.Pages.Add(page);
                        page.NewsArticles.Add(news);
                    }
                    else
                    {
                        page.NewsArticles.Add(news);
                    }
                }
            }
            //There are still some adds to be placed on the pages
            if (advertisementEnumerator < adds.Count())
            {                
                while (advertisementEnumerator < adds.Count())
                {
                    var lastPage = newsPaper.Pages.LastOrDefault();
                    if (!IsPageFull(lastPage))
                    {
                        lastPage.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                    else
                    {
                        var newPage = new Page();
                        newsPaper.Pages.Add(newPage);
                        newPage.Advertisements.Add(adds[advertisementEnumerator]);
                        advertisementEnumerator++;
                    }
                }
            }
            return newsPaper;
        }        

        private bool IsPageFull(Page page)
        {
            return page.NewsArticles.Count + page.Advertisements.Count == maxPageLimit;
        }

        //This is to demo Push model of the publisher-subscriber/observable pattern.
        //Whenever the news source publishes a news, the subscriber will receive the news.
        void ISubscriber.ReceiveNews(News newNews)
        {
            NewsItems.Add(newNews);
        }
    }
}
