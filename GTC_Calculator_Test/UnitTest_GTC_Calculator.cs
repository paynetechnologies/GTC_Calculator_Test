using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Automation_Test
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
    }
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    [Ignore]
    public class UnitTest_GTC_Calculator
    {
        /// <summary>
        /// Used to store information that is provided to unit tests.
        /// </summary>
        private TestContext testContextInstance;
        /// <summary>
        /// Defines the interface through which the user controls the browser.
        /// </summary>
        private IWebDriver driver;

        private string appURL;

        public UnitTest_GTC_Calculator()
        {
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://localhost:81/Content/InterestPage.html";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestMethod]
        [Ignore]
        [TestCategory("Chrome")]
        public void Test_Calculator()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.Id("PrincipalField")).SendKeys("1000000");
            driver.FindElement(By.Id("RateField")).SendKeys("0.05");
            driver.FindElement(By.Id("DurationField")).SendKeys("30");
            driver.FindElement(By.Id("CalculateButton")).Click();
            var amt = driver.FindElement(By.Id("SimpleInterestText")).Text; 
            Assert.AreEqual(amt.ToString(), "$15000.00");
        }

        /*
        var driver = new FirefoxDriver();
        driver.Navigate().GoToUrl("http://localhost/mypage");
        var btn = driver.FindElement(By.CssSelector("#login_button"));
        btn.Click();
        var employeeLabel = driver.FindElement(By.CssSelector("#VCC_VSL"), 10);
        Assert.AreEqual("Employee", employeeLabel.Text);
        driver.Close();
        */

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [Ignore]
        public void Test_FindElements()
        {
            //Get all the links displayed on Page
            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.TagName("a"));
            //Verify there are four links displayed on the page
            Assert.Equals(4, links.Count);
            //Iterate though the list of links and print
            //target for each link
            foreach (ChromeWebElement link in links)
            {
                Console.WriteLine(link.GetAttribute("href"));
            }
                
        }


        [TestCleanup()]
        public void Test_Cleanup()
        {
            driver.Quit();
        }
    }
}