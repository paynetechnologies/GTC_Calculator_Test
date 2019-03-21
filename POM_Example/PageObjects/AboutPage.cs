using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace POMExample.PageObjects
{
    public class AboutPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        //[FindsBy(How = How.XPath, Using = "//input[@name='s']")]
        private IWebElement searchText;

        private IWebElement searchMagnifier;


        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public ResultPage Search(string text)
        {
            searchMagnifier = driver.FindElement(By.CssSelector(".fusion-main-menu-icon"));
            searchMagnifier.Click();

            searchText = driver.FindElement(By.XPath("//input[@name='s']"));
            searchText.SendKeys(text);
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.CssSelector(".fusion-search-submit"))).Click();

            return new ResultPage(driver);
        }
    }
}