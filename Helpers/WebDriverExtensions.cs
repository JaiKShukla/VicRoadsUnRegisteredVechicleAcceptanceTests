using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestFramework.Helpers;

namespace TestFrameWork.Helpers
{
    /// <summary>
    /// This library wrappers on top of native Selenium methods for better/consistent usability and separtion of logic
    /// </summary>
    public static class WebDriverExtentions
    {
        private static IWebDriver _driver;
        private const int TimeoutInSeconds = 30; //30 Secs Timeout, it can be set based upon application

        public static void StartDriver()
        {
            _driver = Browser.BrowserToUse();
        }

        public static void CloseDriver()
        {
            _driver.Quit();
        }

        public static void NavigateTo(string url) => _driver.Navigate().GoToUrl(url);

        public static string PageTitle()
        {
            return _driver.Title;
        }

        public static void WaitFor(this By by)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TimeoutInSeconds));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(NotFoundException));
            try { wait.Until(ExpectedConditions.ElementIsVisible(by)); }
            catch (WebDriverTimeoutException) { Assert.Fail("No element found using: {0} within Timeout of {1} seconds", by, TimeoutInSeconds); }
        }
        public static IWebElement FindAndReturnElement(By by)
        {
            try
            {
                return _driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No element found using: {0}", by);
                return null;
            }
        }

        public static void Click(this By element)
        {
            FindAndReturnElement(element).Click();
        }
        public static void ClearAndEnterText(this By by, string text)
        {
            ClearTextFied(by);
            FindAndReturnElement(by).SendKeys(text);
        }
        public static void ClearTextFied(this By by)
        {
            var element = FindAndReturnElement(by);
            if (element.Displayed)
                element.Clear();
            else
                Assert.Fail("Element with '{0}' is NOT Visible", by);
        }
        public static void SendTabCharacter(this By by)
        {
            FindAndReturnElement(by).SendKeys(Keys.Tab);
        }
        public static void SwitchToOtherWindow()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }
        public static void SendPageDownCharacter(this By by)
        {
            FindAndReturnElement(by).SendKeys(Keys.PageDown);
        }
        public static bool IsElementEnabled(this By by)
        {
            return FindAndReturnElement(by).Enabled;
        }
        public static string RetrieveText(this By by)
        {
            return FindAndReturnElement(by).Text;
        }
        public static void CaptureScreenshots(string scenarioTitle)
        {
            string folderPath = "c:\\temp";
            var testExecutionStartTime = DateTime.Now;
            var screenshotIndex = 0;
            TestFrameWork.Helpers.Files.CreateFolderIfDoesntExist(folderPath);
            var filePath = string.Format(@"{0}\{1}_{2:yyyyMMdd_HHmmss}_{3}", folderPath, scenarioTitle,
                testExecutionStartTime, screenshotIndex++);


            var ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(string.Concat(filePath, ".png"), OpenQA.Selenium.ScreenshotImageFormat.Png);
            TestFrameWork.Helpers.Files.WritePageSourceToHtmlFile(filePath, scenarioTitle, testExecutionStartTime, RetrievePageSource());
        }
        public static string RetrievePageSource()
        {
            return _driver.PageSource;
        }
        public static void SelectByText(this By locator,string  text)
        {
            var selectElement = new SelectElement(FindAndReturnElement(locator));
            selectElement.SelectByText(text);
        }
        public static void SelectByValue(this By locator, string text)
        {
            var selectElement = new SelectElement(FindAndReturnElement(locator));
            selectElement.SelectByValue(text);

          
        }


    }
}
