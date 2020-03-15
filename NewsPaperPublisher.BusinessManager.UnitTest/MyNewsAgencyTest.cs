using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsPaperPublisher.BusinessManager.NewsSource;
using FakeItEasy;
using System.Collections.Generic;
using NewsPaperPublisher.Entities;
using NewsPaperPublisher.BusinessManager.AdvertisementSource;

namespace NewsPaperPublisher.BusinessManager.UnitTest
{
    [TestClass]
    public class MyNewsAgencyTest
    {
        private INewsSource fakeNewsSource;
        private IAdvertisementSource fakeAdSource;
        private MyNewsAgency newsAgency { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            fakeNewsSource = A.Fake<INewsSource>();
            fakeAdSource = A.Fake<IAdvertisementSource>();
            newsAgency = new MyNewsAgency(fakeNewsSource, fakeAdSource);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewsSourceReturningNullNewsItems_ThrowsException()
        {
            //Arrange
            A.CallTo(() => fakeNewsSource.FetchNews(A<string>.Ignored)).Returns(null);

            //Act
            newsAgency.CompileNewsPaper();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NewsSourceReturningEmptyNewsItems_ThrowsException()
        {
            //Arrange
            A.CallTo(() => fakeNewsSource.FetchNews(A<string>.Ignored)).Returns(new List<News>());

            //Act
            newsAgency.CompileNewsPaper();
        }

        [TestMethod]
        public void NewsSourceReturningNewsItems_Succeds()
        {
            //Arrange
            A.CallTo(() => fakeNewsSource.FetchNews(A<string>.Ignored)).Returns(GetNewsItems());
            A.CallTo(() => fakeAdSource.GetAdds()).Returns(GetAds());

            //Act
            var newsPaper = newsAgency.CompileNewsPaper();

            //Assert
            Assert.IsNotNull(newsPaper);
            Assert.IsTrue(newsPaper.Pages.Count == 1);
            Assert.IsTrue(newsPaper.Pages[0].NewsArticles.Count == 2);
            Assert.IsTrue(newsPaper.Pages[0].Advertisements.Count == 2);

        }

        private List<News> GetNewsItems()
        {
            var news = new List<News>()
            {
                new News
                {
                    Headline = "Test Political Headline",
                    Category = NewsCategory.Political,
                    Content = "This is political news content for test purpose",
                    Priority = Entities.Priority.High
                },
                new News
                {
                    Headline = "Test Finance Headline",
                    Category = NewsCategory.Finance,
                    Content = "This is financial news content for test purpose",
                    Priority = Entities.Priority.High
                }
            };
            return news;
        }

        private List<Advertisement> GetAds()
        {
            var adds = new List<Advertisement>
            {
                new Advertisement
                {
                    Product = "Test beauty product",
                    AddCategory = AddCategory.BeautyProducts,
                    AdContent = "This is a test beauty product"
                },
                new Advertisement
                {
                    Product = "Test political banner",
                    AddCategory = AddCategory.Political,
                    AdContent = "This is a test political add"
                }
            };
            return adds;
        }
    }
}
