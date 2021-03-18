# VicRoadsUnRegisteredVechicleAcceptanceTests
Initial acceptance tests 
Structure of the framework:
Feature Folder has the tests/ based on various combination of vehicle type (5 different types) 
Browser – Decides which browser to run the test from app config
DateTimeHelper – To workout Dynamic date based on expression passed.Example :“Today” means get today’s date time used in Permit start date. It can be extended to use expression like 1 day from today, 2 days for today to get different Permit Start Date.
SpecflowHooks – Event Definitions - BeforeScenario and After Scenario to start stop the browser. Before and After Feature can be used to do activities like start stop services if needed or any other cleanup activities.
WebDriverExtensions- Extensions method for the driver to select various elements and interact with it.

PageModels:Two Web pages of Vic roads which has the elements and actions on them.
StepDefinitions:Specflow step definitions mentioning the various actions that a user can perform.
Test Evidence:

 

The test doesn’t read the data from excel as such. I have added capability to read a basic excel file to read excel file data.
