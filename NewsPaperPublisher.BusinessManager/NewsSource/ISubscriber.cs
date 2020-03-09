using NewsPaperPublisher.Entities;

namespace NewsPaperPublisher.BusinessManager.NewsSource
{
    public interface ISubscriber
    {
       void ReceiveNews(News newNews); 
    }
}
