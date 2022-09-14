using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUGUST2022.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AUGUST2022.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;
        LoginPage loginPageObj = new LoginPage();

        [OneTimeSetUp]
        public void LoginActions()
        {
            //open chrome browser
            driver = new ChromeDriver();
            // Login page Object login and initialization and defination
            
            loginPageObj.LoginSteps(driver);
        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }

    }
}

