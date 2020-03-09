using System;
using System.Collections.Generic;
using NewsPaperPublisher.Entities;
using NewsPaperPublisher.SampleRepos;

namespace NewsPaperPublisher.BusinessManager.NewsSource
{
    public class GoogleNewsSource : INewsSource
    {
        public Dictionary<string, ISubscriber> Subscribers = new Dictionary<string, ISubscriber>();
        public string Register(ISubscriber subscriber)
        {
            if (!Subscribers.ContainsValue(subscriber))
            {
                string subscriberId = Guid.NewGuid().ToString();
                Subscribers.Add(subscriberId, subscriber);
                return subscriberId;
            }
            else
            {
                throw new Exception("Already subscribed...");
            }
        }

        public void Unregister(string subscriberId)
        {
            if (Subscribers.ContainsKey(subscriberId))
            {
                Subscribers.Remove(subscriberId);
            }
        }

        public void PublishNews(News news)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Value.ReceiveNews(news);
            }
        }

        public List<News> FetchNews(string subscriberId)
        {
            if (Subscribers.ContainsKey(subscriberId))
            {
                return NewsRepository.GetNews();
            }
            throw new Exception("Please subscribe to get latest news.");
        }
    }

}
