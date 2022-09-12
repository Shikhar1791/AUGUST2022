// open chrome browser
using AUGUST2022.Pages;
using AUGUST2022.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AUGUST2022.Tests

{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        [SetUp]
        public void LoginActions()
        {
            //open chrome browser
            driver = new ChromeDriver();
            // Login page Object login and initialization and defination
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

            //Home page object initialisation and defination
            HomePage homePageObj = new HomePage();
            homePageObj.GoTOTMpage(driver);
        }
        [Test]
        public void CreateTMTest()
        {
            // Tm page object initialisation and defination
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);

        }

        [Test]
        public void EditTMTest()
        {

            // Edit Tm
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTm(driver);

        }
        [Test]
        public void DeleteTMTest()
        {


            // Delete TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTM(driver);

        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }

       

        

        
    
    }
}
