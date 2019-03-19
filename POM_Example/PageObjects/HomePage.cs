using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.PageObjects;


namespace POMExample.PageObjects
{
    class HomePage
    {

        private IWebDriver driver;
        private IWebElement about;
        private IWebElement searchIcon;

        public HomePage(IWebDriver driver)
        {
            driver = new ChromeDriver();
            var cn = driver.FindElement(By.ClassName("fusion-main-menu-icon"));
            var cs = driver.FindElement(By.CssSelector(".fusion-main-menu a[href*='about']"));

            //this.driver = driver;
            //[FindsBy(How = How.ClassName, Using = "fusion-main-menu-icon")]
            //[FindsBy(How = How.CssSelector, Using = ".fusion-main-menu a[href*='about']")]
            //PageFactory.InitElements(driver, this);
        }
        public void goToPage()
        {
            driver.Navigate().GoToUrl("http://www.swtestacademy.com");
        }

        public AboutPage goToAboutPage()
        {
            about.Click();
            return new AboutPage(driver);
        }
    } 
}
