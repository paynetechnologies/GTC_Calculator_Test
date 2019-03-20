using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace POMExample.PageObjects
{
    public class LoginPage
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;
        IWebElement usernameLocator;
        IWebElement passwordLocator;
        IWebElement loginButtonLocator;


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

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            if (!driver.Title.Equals("Login"))
            {
                // Alternatively, we could navigate to the login page, perhaps logging out first
                throw new Exception("This is not the login page");
            }

            // The login page contains several HTML elements that will be represented as WebElements.
            // The locators for these elements should only be defined once.
            this.usernameLocator = driver.FindElement(By.Id("username"));
            this.passwordLocator = driver.FindElement(By.Id("password"));
            this.loginButtonLocator = driver.FindElement(By.Id("login"));
        }


        // The login page allows the user to type their username into the username field
        public LoginPage TypeUsername(String username)
        {
            // This is the only place that "knows" how to enter a username
            this.usernameLocator.SendKeys(username);

            // Return the current page object as this action doesn't navigate to a page represented by another PageObject
            return this;
        }

        // The login page allows the user to type their password into the password field
        public LoginPage TypePassword(String password)
        {
            // This is the only place that "knows" how to enter a password
            this.passwordLocator.SendKeys(password);

            // Return the current page object as this action doesn't navigate to a page represented by another PageObject
            return this;
        }

        // The login page allows the user to submit the login form
        public HomePage SubmitLogin()
        {
            // This is the only place that submits the login form and expects the destination to be the home page.
            // A seperate method should be created for the instance of clicking login whilst expecting a login failure. 
            this.loginButtonLocator.Submit();

            // Return a new page object representing the destination. Should the login page ever
            // go somewhere else (for example, a legal disclaimer) then changing the method signature
            // for this method will mean that all tests that rely on this behaviour won't compile.
            return new HomePage(driver);
        }

        // The login page allows the user to submit the login form knowing that an invalid username and / or password were entered
        public LoginPage SubmitLoginExpectingFailure()
        {
            // This is the only place that submits the login form and expects the destination to be the login page due to login failure.
            this.loginButtonLocator.Submit();

            // Return a new page object representing the destination. Should the user ever be navigated to the home page after submiting a login with credentials 
            // expected to fail login, the script will fail when it attempts to instantiate the LoginPage PageObject.
            return new LoginPage(driver);
        }

        // Conceptually, the login page offers the user the service of being able to "log into"
        // the application using a user name and password. 
        public HomePage LoginAs(String username, String password)
        {
            // The PageObject methods that enter username, password & submit login have already defined and should not be repeated here.
            TypeUsername(username);
            TypePassword(password);
            return SubmitLogin();
        }

        public String getErrorMessage()
        {
            // So we can verify that the correct error is shown
            return null;
        }


        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.bing.com/";

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

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
