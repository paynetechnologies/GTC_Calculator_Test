using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;


namespace POMExample.PageObjects
{
    public class HomePage
    {

        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = ".fusion-main-menu a[href*='about']")]
        private IWebElement about;
        //var cs = driver.FindElement(By.CssSelector(".fusion-main-menu a[href*='about']"));
        //this.about = driver.FindElement(By.CssSelector(".fusion-main-menu a[href*='about']"));

        [FindsBy(How = How.ClassName, Using = "fusion-main-menu-icon")]
        private IWebElement searchIcon;
        //var cn = driver.FindElement(By.ClassName("fusion-main-menu-icon"));
        //this.searchIcon = driver.FindElement(By.ClassName("fusion-main-menu-icon"));

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl("https://www.swtestacademy.com");
        }

        public AboutPage GoToAboutPage()
        {
            this.about.Click();
            return new AboutPage(driver);
        }
    } 
}
