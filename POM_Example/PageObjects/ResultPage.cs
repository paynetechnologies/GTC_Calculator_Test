using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMExample.PageObjects
{
    public class ResultPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "#posts-container>article:nth-child(1)")]
        private IWebElement firstArticle;
        //this.firstArticle = driver.FindElement(By.CssSelector("#posts-container>article:nth-child(1)"));

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void clickOnFirstArticle()
        {
            this.firstArticle.Click();
        }
    }
}
