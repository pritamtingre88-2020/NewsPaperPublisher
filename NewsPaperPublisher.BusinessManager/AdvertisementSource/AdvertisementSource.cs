using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPaperPublisher.Entities;
using NewsPaperPublisher.SampleRepos;

namespace NewsPaperPublisher.BusinessManager.AdvertisementSource
{
    public class AdvertisementSource : IAdvertisementSource
    {
        public List<Advertisement> GetAdds()
        {
            return AdvertisementRepository.GetAdds();
        }
    }
}
