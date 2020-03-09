using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPaperPublisher.Entities;

namespace NewsPaperPublisher.BusinessManager.NewsSource
{
    //This could be another news source which supplies news to registered subscribers
    public class PTINewsSource : INewsSource
    {
        public List<News> FetchNews(string subscriberId)
        {
            throw new NotImplementedException();
        }

        public void PublishNews(News news)
        {
            throw new NotImplementedException();
        }

        public string Register(ISubscriber subscriber)
        {
            throw new NotImplementedException();
        }

        public void Unregister(string subscriberId)
        {
            throw new NotImplementedException();
        }
    }
}
