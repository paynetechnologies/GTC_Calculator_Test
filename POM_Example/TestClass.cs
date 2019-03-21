#define NUnit_OFF

#if NUnit
using NUnit.Framework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
# endif

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMExample.PageObjects;


namespace POMExample
{

#if NUnit
    [TestFixture]
#else
    [TestClass]
#endif
    public class TestClass
    {
        private IWebDriver driver;

#if NUnit
        [SetUp]
#else
        [TestInitialize()]
#endif
        public void SetUp()
        {
            driver = new ChromeDriver();
            // Need to Maximize window in order for About button to be visible
            driver.Manage().Window.Maximize();
        }

#if NUnit
        [Test]
#else
        [TestMethod]
#endif
        public void SearchTextFromAboutPage()
        {
            HomePage home = new HomePage(driver);
            home.goToPage();

            AboutPage about = home.GoToAboutPage();
            ResultPage result = about.Search("selenium c#");

            result.clickOnFirstArticle();
        }



#if NUnit
        [TearDown]
        public void TearDown()
        {
            if (this.driver != null)
            {
                driver.Quit();
            }
        }
#else
        [TestCleanup()]
        public void Test_Cleanup()
        {
            if (this.driver != null)
            {
                driver.Quit();
            }
        }
#endif
    }
}