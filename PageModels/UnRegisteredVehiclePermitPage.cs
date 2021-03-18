using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using TestFrameWork.Helpers;

namespace TestFrameWork.PageModels
{
    public class UnRegisteredVehiclePermit
    {


        #region WebElement

        private readonly By _vehicleTypeDropdwon = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_VehicleType_DDList");
        private readonly By _passengerVehicleTypeDropdwon = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_PassengerVehicleSubType_DDList");
        private readonly By _address = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_AddressLine_SingleLine_CtrlHolderDivShown");
        private readonly By _permitDurationDropDown = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_PermitDuration_DDList");
        private readonly By _nextButton = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_btnNext");
        private readonly By _permiteDate = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_PermitStartDate_Date");
        private readonly By _passengerCarryingCapacity = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_GoodsVehicleSubType_DDList");
        private readonly By _engineCapacity = By.Id("ph_pagebody_0_phthreecolumnmaincontent_0_panel_MotorcycleSubType_DDList");
        #endregion


        #region Action

        public UnRegisteredVehiclePermit SelectFromVehicleType(string text)
        {
            _vehicleTypeDropdwon.SelectByValue(text);
            return this;
        }

        public UnRegisteredVehiclePermit EnterAddress(string address)
        {
            _address.ClearAndEnterText(address);
            return this;
        }



        public UnRegisteredVehiclePermit SelectFromPassengerVehicleType(string text)
        {
            _passengerVehicleTypeDropdwon.SelectByText(text);
            return this;
        }

        public UnRegisteredVehiclePermit SelectPermitDuration(string text)
        {
            _permitDurationDropDown.SelectByText(text);
            return this;
        }


        public UnRegisteredVehiclePermit ClickNextButton()
        {
            _nextButton.Click();
            return this;
            
        }

        public UnRegisteredVehiclePermit EnterPermitStartDate(string permitDate)
        {
           _permiteDate.ClearAndEnterText(permitDate);
            return this;

        }


        public UnRegisteredVehiclePermit SelectCarryingCapacity(string text)
        {
            _passengerCarryingCapacity.SelectByText(text);
            return this;
        }


        public UnRegisteredVehiclePermit SelectEngineCapacity(string text)
        {
            _engineCapacity.SelectByText(text);
            return this;
        }
        #endregion
    }
}
