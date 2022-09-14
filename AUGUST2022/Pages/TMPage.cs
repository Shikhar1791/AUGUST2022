
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AUGUST2022.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Create new Time Record


            // Click on create New Button
            IWebElement CreateNewButton = driver.FindElement(By.XPath("//*[@id=\'container\']/p/a"));
            CreateNewButton.Click();

            // Select "Time" option from Typecode Dropdown
            IWebElement typeCodeDropdwon = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdwon.Click();
            Thread.Sleep(2000);
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            // Input Code
            IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
            CodeTextbox.SendKeys("shikhartest");
            Thread.Sleep(1000);


            // Type description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("shikhartest");
            Thread.Sleep(1000);


            // Input price
            IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("150.00");
            Thread.Sleep(1000);

            // Click on save Button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3000);


            // Check if record Created is present in table
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            
 
        }

        public string GetCode(IWebDriver driver)
        {
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            return newCode.Text;
        }

        public string GetDescription(IWebDriver driver)
        {
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            return newDescription.Text;
        }

        public string GetPrice(IWebDriver driver)
        {
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));
            return newPrice.Text;

        }

        public void EditTm(IWebDriver driver, string description)
        {
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\'tmsGrid\']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1500);

            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (findRecordCreated.Text == "shikhartest")
             {
               // Click on the Edit Button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(2000);
             }
           else
             {
                Assert.Fail("Record to be edited hasn't been found. Record not edited.");
             }

            // Click on Code Textbox and set new Code
            IWebElement codeTextBox1 = driver.FindElement(By.Id("Code"));
            codeTextBox1.Clear();
            codeTextBox1.SendKeys("Pandey");
            Thread.Sleep(2000);

            // Click on Description Textbox and update description
            IWebElement descriptionTextBox1 = driver.FindElement(By.Id("Description"));
            descriptionTextBox1.Clear();
            Thread.Sleep(2000);

            descriptionTextBox1.SendKeys(description);
            Thread.Sleep(2000);

            // Click on Price Textbox and update new price
            // Click on "Price per unit" textbox and clear the price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span"));
            priceTag.Click();


            IWebElement pricePerUnit1 = driver.FindElement(By.Id("Price"));
            pricePerUnit1.Clear();


            priceTag.Click();

            pricePerUnit1.SendKeys("180.00");
            Thread.Sleep(2000);

            // Click On save button to save record
            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();
            Thread.Sleep(3000);

            // Assert that Time record has been edited.
            IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton1.Click();
            Thread.Sleep(1500);

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(editedCode.Text == "Pandey", "Actual Code and expected code do not match.");
            //Assert.That(editedDescription.Text == "Pandey", "Actual Description and expected description do not match.");
            //Assert.That(editedPrice.Text == "$180.00", "Actual Price and expected price do not match.");



        }

        public string GetEditedDescription(IWebDriver driver)
        {
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            return editedDescription.Text;

        }

        public void DeleteTM(IWebDriver driver)
        {
            // Delete Time and material
            // Go to the last page where edited record will be
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(1500);


            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "Pandey")
            {

                // Click on the Delete Button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(3000);

                driver.SwitchTo().Alert().Accept();

            }
            else
            {
                Assert.Fail("New Record to be deleted is not found. Record not deleted.");
            }

            // Assert that Time record has been deleted.
            IWebElement goToLastPageBtn1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageBtn1.Click();
            Thread.Sleep(3000);
            IWebElement code = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement description = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement price = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(code.Text != "Pandey", "Code record hasn't been deleted."); 
            Assert.That(description.Text != "Pandey", "Description record hasn't been deleted.");
            Assert.That(price.Text != "$180.00", "Price record hasn't been deleted.");

        }

    }
}
