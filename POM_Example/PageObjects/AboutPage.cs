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

        [FindsBy(How = How.CssSelector, Using = "#sidebar input[class='s']")]
        private IWebElement searchText;
        //this.searchText = driver.FindElement(By.CssSelector("input[class='s']"));

        public AboutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public ResultPage Search(string text)
        {
            searchText.SendKeys(text);
            //wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.CssSelector("fusion-search-submit searchsubmit"))).Click();
            wait.Until(condition: ExpectedConditions.ElementToBeClickable(By.CssSelector("#sidebar .searchsubmit"))).Click();
            return new ResultPage(driver);
        }
    }
}