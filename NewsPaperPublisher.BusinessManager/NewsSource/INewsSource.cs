using NewsPaperPublisher.Entities;
using System.Collections.Generic;

namespace NewsPaperPublisher.BusinessManager.NewsSource
{
    /// <summary>
    /// This interface defines framework for managing subscribers and push/pull for registered subscribers
    /// </summary>
    public interface INewsSource
    {
        /// <summary>
        /// Registers a subscriber for news feed
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>Unique subscriber Id for the registered subscriber</returns>
        string Register(ISubscriber subscriber);


        /// <summary>
        /// Unregisters a subscriber from the news feed
        /// </summary>
        /// <param name="subscriberId">subscriber Id to unregister</param>
        void Unregister(string subscriberId);


        /// <summary>
        /// Broadcasts/Pushes new news to all the registered subscribers
        /// </summary>
        /// <param name="news"></param>
        void PublishNews(News news);

        /// <summary>
        /// Pull mechanism for subscribers to fetch news from the news source.
        /// </summary>
        /// <param name="subscriberId"></param>
        /// <returns></returns>
        List<News> FetchNews(string subscriberId);
    }
}
