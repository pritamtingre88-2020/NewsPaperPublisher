using NewsPaperPublisher.Entities;
using System.Collections.Generic;

namespace NewsPaperPublisher.SampleRepos
{
    public static class AdvertisementRepository
    {
        public static List<Advertisement> GetAdds()
        {
            var adds = new List<Advertisement>
            {
                new Advertisement
                {
                    Product = "Beauty soap",
                    AddCategory = AddCategory.BeautyProducts,
                    AdContent = "This is a beautiful soap with excellent aroma to make you feel refreshed."
                },
                new Advertisement
                {
                    Product = "Vote for BPP",
                    AddCategory = AddCategory.Political,
                    AdContent = "Vote for BPP as we are working day in and day out to make our country extremely powerful."
                },
                 new Advertisement
                {
                    Product = "Cricket Bat",
                    AddCategory = AddCategory.SportsAccessories,
                    AdContent = "A brand new Kashmir willow bat. Buying this bat would be a master stroke to uplift your career."
                }
            };
            return adds;
        }
    }
}
