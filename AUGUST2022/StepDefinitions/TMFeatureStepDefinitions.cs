using System;
using AUGUST2022.Pages;
using AUGUST2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace AUGUST2022.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        TMPage tmPageObj = new TMPage();
        HomePage homePageObj = new HomePage();
        LoginPage loginPageObj = new LoginPage();

        [Given(@"user logged into turnup portal successfully")]
        public void GivenUserLoggedIntoTurnupPortalSuccessfully()
        {
            //open chrome browser
            driver = new ChromeDriver();
            // Login page Object login and initialization and defination
           
            loginPageObj.LoginSteps(driver);
        }

    

        [When(@"user navigate to Time and material page")]
        public void WhenUserNavigateToTimeAndMaterialPage()
        {

            
            homePageObj.GoTOTMpage(driver);

        }

        [When(@"user create time and material record")]
        public void WhenUserCreateTimeAndMaterialRecord()
        {
          
            tmPageObj.CreateTM(driver);

        }

        [Then(@"record should be created successfully")]
        public void ThenRecordShouldBeCreatedSuccessfully()
        {

            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "shikhartest", "Actual code and expected code do not match");
            Assert.That(newDescription == "shikhartest", "Actual description and expected description do not match");
            Assert.That(newPrice == "$150.00", "Actual price and expected price do not match");
        }

        [When(@"user update '([^']*)','([^']*)' and '([^']*)' on existing time and material record")]
        public void WhenUserUpdateAndOnExistingTimeAndMaterialRecord(string description, string code, string price)
        {
            tmPageObj.EditTm(driver, description, code, price);
        }

        [Then(@"record should have the updated'([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenRecordShouldHaveTheUpdatedAnd(string description, string code, string price)
        {
            string editedDescription = tmPageObj.GetEditedDescription(driver);
            string editedCode = tmPageObj.GetCode(driver);
            string editedPrice = tmPageObj.GetPrice(driver);

            // Assertion
            Assert.That(editedDescription == description, "Actual Description and expected description do not match.");
            Assert.That(editedCode == code, "Actual Code and expected code do not match.");
            Assert.That(editedPrice == price, "Actual Price and expected price do not match.");
        }










    }
}
