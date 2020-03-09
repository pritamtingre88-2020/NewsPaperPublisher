using System.Collections.Generic;

namespace NewsPaperPublisher.Entities
{
    public class Page
    {
        public List<News> NewsArticles = new List<News>();

        public List<Advertisement> Advertisements = new List<Advertisement>();
    }
}
