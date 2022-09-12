
using OpenQA.Selenium;

namespace AUGUST2022.Pages
{
    public class LoginPage
    {
        public void LoginSteps(IWebDriver driver)

        {
            driver.Manage().Window.Maximize();

            // launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(1000);

            // identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");
            // identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\'loginForm\']/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(1000);
            // check if user is logged in succesfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\'logoutForm\']/ul/li/a"));

            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in sucessfully, test passed");
            }
            else
            {
                Console.WriteLine("Logged in Failed,test failed");


            }

        }
    }
}