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
        

            //Home page object initialisation and defination
            HomePage homePageObj = new HomePage();
            TMPage tmPageObj = new TMPage();


        [Test, Order(1), Description("check if user is able to to create TM record " )]
        public void CreateTMTest()
        {
            homePageObj.GoTOTMpage(driver);
            // Tm page object initialisation and defination
            
            tmPageObj.CreateTM(driver);

        }

        [Test, Order(2), Description("Check if user able to edit created TM record")]
        public void EditTMTest()
        {
            homePageObj.GoTOTMpage(driver);
            // Edit Tm

            //tmPageObj.EditTm(driver);

        }
        [Test, Order(3), Description("Check if used deleted edited TM record")]
        public void DeleteTMTest()
        {

            homePageObj.GoTOTMpage(driver);
            // Delete TM

            tmPageObj.DeleteTM(driver);
            
        }


       

        

        
    
    }
}
