using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion

        public void LoginSteps()
        {
            // Read data from Excel sheet 

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");

            // Navigate to Login page 
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

            // click on SignIn tab 

            SignIntab.Click();

            // wait 
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//button[contains(text(),'Login')]"), 10);

            // Write email from excel sheet 
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            // write password in excel sheet 
            Password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            // click on login button 

            LoginBtn.Click();


        }
    }
}