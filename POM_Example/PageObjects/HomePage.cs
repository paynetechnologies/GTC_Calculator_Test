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

        [FindsBy(How = How.ClassName, Using = "fusion-main-menu-icon")]
        private IWebElement searchIcon;

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
            try
            {
                //this.about = driver.FindElement(By.CssSelector(".fusion-main-menu a[href*='about']"));
                this.about.Click();
                return new AboutPage(driver);
            }
            catch
            {
                throw;
            }
        }
    } 
}
