using OpenQA.Selenium;
using TestFrameWork.Helpers;

namespace TestFrameWork.PageModels
{
    public class UnRegisteredVehiclePermitSelectPermitTypePage 
    {
        #region WebElement

        private readonly By progressBarTitle = By.ClassName("progress-bar-title");
     
        #endregion


        #region Action

        public string GetProgressBarTitle()
        {
           var progressbarTitle = progressBarTitle.RetrieveText();
            return progressbarTitle;
        }


   




        #endregion
    }
}
