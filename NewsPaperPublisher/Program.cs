using NewsPaperPublisher.BusinessManager;
using NewsPaperPublisher.BusinessManager.NewsSource;
using NewsPaperPublisher.Entities;
using System;

namespace NewsPaperPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            var newsSource = new GoogleNewsSource();

            var newsAgency = new MyNewsAgency(newsSource);

            //Example demoing push model of Observable pattern
            //The news source would publish/push this news to all it's subscribers
            newsSource.PublishNews(new News { Headline = "Microsoft jumping into gaming space", Priority= Priority.Low, Category = NewsCategory.Technical, Content = "A good news for gaming enthusiasts as Microsoft to soon launch a new gaming platform." });

            var newsPaper = newsAgency.CompileNewsPaper();
            Console.WriteLine("--------------" + newsPaper.Name + "-" + newsPaper.Date.ToShortDateString() + "-----------------");
            int pageNumber = 1;
            foreach(var page in newsPaper.Pages)
            {
                Console.WriteLine("-----Page -" + pageNumber + "--------");
                foreach(var news in page.NewsArticles)
                {
                    Console.WriteLine(news.Headline);
                    Console.WriteLine(news.Content);
                    Console.WriteLine("-----------------------------------");
                }
                Console.WriteLine("----------Advertisements Section-------------------");
                foreach (var add in page.Advertisements)
                {
                    Console.WriteLine(add.Product);
                    Console.WriteLine(add.AdContent);
                    Console.WriteLine("-----------------------------------");
                }
                pageNumber++;
            }
            Console.ReadLine();
        }
    }
}
