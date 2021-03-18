using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;


namespace TestFramework.Helpers
{
    /// <summary>
    /// Provides capability to use multiple Browsers, driven through Appconfig file
    /// </summary>
    public static class Browser
    {
        private static IWebDriver _driver; // static WebDriver instance shared through the whole scenario

        public static IWebDriver BrowserToUse()
        {
            
            switch (ConfigurationManager.AppSettings["Browser"].ToLower())
            {
                case "ie":
                    var options = new InternetExplorerOptions();
                    options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    _driver = new InternetExplorerDriver(options);
                    break;
                case "chrome":
                    _driver = new ChromeDriver();
                    break;
                default:
                    _driver = new ChromeDriver();
                    break;
            }
            _driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);// Implicit Wait.. It ll wait min 10 secs before failing
            _driver.Manage().Window.Maximize();
            return _driver;
        }

    }
}