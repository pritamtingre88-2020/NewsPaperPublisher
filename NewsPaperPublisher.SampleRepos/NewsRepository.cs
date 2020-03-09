using NewsPaperPublisher.Entities;
using System.Collections.Generic;

namespace NewsPaperPublisher.SampleRepos
{
    public static class NewsRepository
    {        
        public static List<News> GetNews()
        {
            var news = new List<News>()
            {
                new News
                {
                    Headline = "Maharashtra chooses its new CM",
                    Category = NewsCategory.Political,
                    Content = "Maharashtra chooses its new CM and it's none other than Mr. X",
                    Priority = Priority.High
                },
                new News
                {
                    Headline = "Yesss Bank acount holders in deep trouble",
                    Category = NewsCategory.Finance,
                    Content = "Be alert if you are a Yesss Bank customer as you can now only withdraw a max amount of 50k.",
                    Priority = Priority.High
                },
                new News
                {
                    Headline = "Online fraudsters dupe students for 30K",
                    Category = NewsCategory.Crime,
                    Content = "Online fraudsters managed to dupe a college student of 30K when we was trying to purchase shoes online from a popular shopping website.",
                    Priority = Priority.Medium
                },
                new News
                {
                    Headline = "India Women enters final",
                    Category = NewsCategory.Sports,
                    Content = "Indian womens cricket team enters maiden T20 final.",
                    Priority = Priority.High
                },
                new News
                {
                    Headline = "Ajay's Tanaji creates record",
                    Category = NewsCategory.Entertainment,
                    Content = "Ajay Devgan's Tanaji has created a record at box office after it crossed a whooping 300 crore mark.",
                    Priority = Priority.Low
                },
                new News
                {
                    Headline = "A 16 year old Indian girl tops ICC rankings",
                    Category = NewsCategory.Sports,
                    Content = "Indias 16 year old rising sensastion tops ICC ranking for T20 batters after scoring heavily in the ICC world cup tournment",
                    Priority = Priority.Medium
                },
                new News
                {
                    Headline = "Sensex tanks to record fall after corona threat",
                    Category = NewsCategory.Finance,
                    Content = "Sensex today tanled by a whooping 800 points after the rise in number of corona patients in India.",
                    Priority = Priority.Low
                },
                new News
                {
                    Headline = "Delhi on high alert for corona",
                    Category = NewsCategory.Health,
                    Content = "The govrnment officials raised a red alert and have asked public to be safe and take necessary precautions after the rise in number of corona virus cases rose in Delhi",
                    Priority = Priority.Low
                }
            };
            return news;
        }
    }
}
