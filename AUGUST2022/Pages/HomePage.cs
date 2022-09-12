
using AUGUST2022.Utilities;
using OpenQA.Selenium;

namespace AUGUST2022.Pages
{
    public class HomePage
    {
        public void GoTOTMpage(IWebDriver driver)

        {

            // Navigate to Time & Material Page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();
            WaitHelpers.WaitToBeClickable(driver, "Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 3);
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();


        }
    }
}
