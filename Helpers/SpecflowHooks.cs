using System;
using TechTalk.SpecFlow;

namespace TestFrameWork.Helpers
{
    /// <summary>
    /// This Library provides the Specflow Hooks
    /// </summary>
    [Binding]
    public sealed class SpecflowHooks
    {
        private  readonly ScenarioContext scenarioContext;

        public SpecflowHooks(ScenarioContext scenarioContext)
        {
           this.scenarioContext = scenarioContext;
        }
        [BeforeFeature()]
        public static void BeforeFeature()
        {
            //Do services start
        }
        [AfterFeature()]
        public static void AfterFeature()
        {
            //End Services etc other non functional cleanup
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            WebDriverExtentions.StartDriver();
        }
        [AfterScenario]
        public static void AfterScenario()
        {
            WebDriverExtentions.CloseDriver();
        }
        /// <summary>
        /// This Method will capture screenshots at error when @captureScreenshotAtError is specified by any feature/scenario
        /// </summary>
        [AfterStep("captureScreenshotAtError")]
        public void CaptureScreenshotAtError()
        {
            
            var randomNumber = DateTime.Now.Ticks.ToString();
            var scenarioName = string.Concat(scenarioContext.ScenarioInfo.Title, randomNumber);
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
                WebDriverExtentions.CaptureScreenshots(scenarioName);
        }
    }
}
