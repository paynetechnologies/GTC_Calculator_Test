//using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExample.PageObjects;

namespace POMExample
{
    [TestClass]
    public class TestClass
    {
        private IWebDriver driver;

        //NUnit [SetUp]
        [TestInitialize()]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        // NUint [Test]
        [TestMethod]
        public void SearchTextFromAboutPage()
        {
            HomePage home = new HomePage(driver);
            home.goToPage();

            AboutPage about = home.GoToAboutPage();
            ResultPage result = about.Search("selenium c#");

            result.clickOnFirstArticle();
        }

        // NUnit [TearDown]
        //public void TearDown()
        //{
        //    driver.Close();
        //}

        [TestCleanup()]
        public void Test_Cleanup()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}