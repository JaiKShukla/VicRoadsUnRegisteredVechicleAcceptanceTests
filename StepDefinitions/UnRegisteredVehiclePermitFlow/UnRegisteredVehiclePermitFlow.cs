using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestFrameWork.Helpers;
using TestFrameWork.PageModels;

namespace TestFrameWork.StepDefinitions
{
    [Binding]
    class UnRegisteredVehiclePermitFlow
    {
        private static string unRegisteredVechiclePermitURL =
            "https://www.vicroads.vic.gov.au/registration/limited-use-permits/unregistered-vehicle-permits/get-an-unregistered-vehicle-permit";

        [Given(@"the user is on Unregistered Vehicle Permit application form")]
        public void GivenTheUserIsOnUnregisteredVehiclePermitApplicationForm()
        {
            WebDriverExtentions.NavigateTo(unRegisteredVechiclePermitURL);

        }


        [When(@"the user registers the vehicle with these details")]
        public void WhenTheUserRegistersTheVehicleWithTheseDetails(Table table)
        {
            var rows = table.Rows.First();
            var vehicleType = rows["Vehicle Type"];
            var passengerAddress = rows["Address"];
            var permitStartDate = rows["Permit Start Date"];
            var permitDuration = rows["Permit Duration"];

            var permitStartDateFormatted = DateTimeHelper.GetDate(permitStartDate);

            switch (vehicleType)
            {

                case "PassengerVehicle":
                    var passengerVehicleType = rows["Passenger Vehicle Type"];
                    new UnRegisteredVehiclePermit().SelectFromVehicleType(vehicleType)
                        .SelectFromPassengerVehicleType(passengerVehicleType)
                        .EnterAddress(passengerAddress)
                        .EnterPermitStartDate(permitStartDateFormatted)
                        .SelectPermitDuration(permitDuration)
                        .ClickNextButton();
                    break;

                case "GoodsCarryingVehicle":
                    var carryingCapacity = rows["CarryingCapacity"];
                    new UnRegisteredVehiclePermit().SelectFromVehicleType(vehicleType)
                         .SelectCarryingCapacity(carryingCapacity)
                        .EnterAddress(passengerAddress)
                        .EnterPermitStartDate(permitStartDateFormatted)
                        .SelectPermitDuration(permitDuration)
                        .ClickNextButton();
                    break;

                case "PrimeMover":
                case "Trailer":
                    new UnRegisteredVehiclePermit().SelectFromVehicleType(vehicleType)
                        .EnterAddress(passengerAddress)
                        .EnterPermitStartDate(permitStartDateFormatted)
                        .SelectPermitDuration(permitDuration)
                        .ClickNextButton();
                    break;

                case "Motorcycle":
                    var engineCapacity = rows["EngineCapacity"];
                    new UnRegisteredVehiclePermit().SelectFromVehicleType(vehicleType)
                        .SelectEngineCapacity(engineCapacity)
                        .EnterAddress(passengerAddress)
                        .EnterPermitStartDate(permitStartDateFormatted)
                        .SelectPermitDuration(permitDuration)
                        .ClickNextButton();
                    break;



            }
           



        }

        [Then(@"the user can proceed to Select Permit Type option")]
        public void ThenTheUserCanProceedToSelectPermitTypeOption()
        {
            var expectedBarTitle = "Step 2 of 7 : Select permit type";
            var actualProgressBarTitle = new UnRegisteredVehiclePermitSelectPermitTypePage().GetProgressBarTitle();
            Assert.AreEqual(expectedBarTitle,actualProgressBarTitle);
        }



    }
}

