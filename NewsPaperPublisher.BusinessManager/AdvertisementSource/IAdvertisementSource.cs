using NewsPaperPublisher.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPaperPublisher.BusinessManager.AdvertisementSource
{
    public interface IAdvertisementSource
    {
        List<Advertisement> GetAdds();
    }
}
