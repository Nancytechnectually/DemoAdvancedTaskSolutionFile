using System;
using System.Diagnostics;
using System.Threading;
using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace MarsFramework.Pages
{
     public class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//form/div[1]/div/div[2]/div/div[1]/input")]
        private IWebElement Title { get; set; }


        //Enter the Title in textbox
        [FindsBy(How = How.XPath, Using = "//*[text()= 'Title']")]
        private IWebElement TitleOFForm { get; set; }





        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        private IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }

        //Storing the table of available days as Sunday 
        [FindsBy(How = How.XPath, Using = "//Label[text()= 'Sun']/preceding-sibling::*")]
        private IWebElement DayToBeSelectedSun { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[2]/div[2]/input[1]")]
        private IWebElement StartTimeDropDownSun { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[2]/div[3]/input[1]")]
        private IWebElement EndTimeDropDownSun { get; set; }



        //Storing the table of available days as Monday 
        [FindsBy(How = How.XPath, Using = "//Label[text()= 'Mon']/preceding-sibling::*")]
        private IWebElement DayToBeSelectedMon { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDownMon { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDownMon { get; set; }


        //Storing the table of available days as Tuesday 
        [FindsBy(How = How.XPath, Using = "//Label[text()= 'Tue']/preceding-sibling::*")]
        private IWebElement DayToBeSelectedTue { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[4]/div[2]/input[1]")]
        private IWebElement StartTimeDropDownTue { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[4]/div[3]/input[1]")]
        private IWebElement EndTimeDropDownTue { get; set; }



        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        private IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        private IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        private IWebElement ActiveOption { get; set; }


        //Click on Uplad Work Sample option
        [FindsBy(How = How.CssSelector, Using = "#service-listing-section > div.ui.container > div > form > div:nth-child(9) > div > div.twelve.wide.column > section > div > label > div > span > i")]
        private IWebElement Upload { get; set; }







        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        private IWebElement Save { get; set; }

        public void AddTitleOfNewListing()
        {
            

            ManageListings manageListings = new ManageListings();


            // Reading Data from excel sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");



            //Read unique Title from Excel Sheet (It giver 10 Unique values after that we need to delete old listings to get new Unique value)

            TitleKey1 = GlobalDefinitions.ExcelLib.ReadData(ManageListings.getVariablek(), "Title");


            //  Write title selected in Title field
            Title.SendKeys(TitleKey1);

        }
        public string TitleKey1;
        public string getNewAddeditle()
        {

            return TitleKey1;

        }


        public void EditListing(int Row)
        {
           int  Row1 = 10 + Row;
            

            // Reading data from excel sheet 
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            Title.Clear();



            // Writing updated title read from excel sheet 

            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(Row1, "Title"));


            // Save the listings


            Save.Click();




        }

      
        public string GetTitleCurrentValue()
        {

            return Title.GetAttribute("value").ToString();

        }

        public void clickShareSkillBtn()
        {

            // Click on shareskill Button 
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.LinkText("Share Skill"), 10);
            ShareSkillButton.Click();

        }

        public Boolean CheckPageExists()
        {

            // check if we are share skill form page 

            Boolean x = TitleOFForm.Displayed;

            return x;

        }

        public void AddListing()
        {
            // Read data from Excel sheet 
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");


            // adding description from excelsheet 
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));


            // Select Category dropdown

            CategoryDropDown.Click();

            //Value1 = "Programming & Tech";
            Value1 = GlobalDefinitions.ExcelLib.ReadData(2, "Category");

            // Value2 = "QA";
            Value2 = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");


            //select Category by value
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[text()='" + Value1 + "']"), 10);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[text()='" + Value1 + "']")).Click();


            // Select SubCategory dropdown

            SubCategoryDropDown.Click();


            //select Category by value
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[text()='" + Value2 + "']"), 10);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[text()='" + Value2 + "']")).Click();

            // add tag 

            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Tags.SendKeys(Keys.Return);


            // Select Service Type as Hourly basis 

            if (ServiceTypeOptions.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType")))
            {
                ServiceTypeOptions.Click();

            }

            // Select Location Type as On-site 

            if (LocationTypeOption.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "LocationType")))
            {
                LocationTypeOption.Click();

            }

            // Select start and end date

            StartDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Startdate"));
            EndDateDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Enddate"));

            // select day of the week and corresponding time
            String DayFromExcel = GlobalDefinitions.ExcelLib.ReadData(2, "Selectday");

            // Select Available days
            if (DayFromExcel == "Sun")
            {

                DayToBeSelectedSun.Click();
                StartTimeDropDownSun.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDownSun.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));


            }
            if (DayFromExcel == "Mon")

            {
                DayToBeSelectedMon.Click();
                StartTimeDropDownMon.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDownMon.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));


            }
            if (DayFromExcel == "Tue")

            {
                DayToBeSelectedTue.Click();
                StartTimeDropDownTue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Starttime"));
                EndTimeDropDownTue.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Endtime"));

            }



            // Select Skill Trade as credit



            if (SkillTradeOption.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade")))
            {
                SkillTradeOption.Click();

                if (GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade") == "Credit")

                {
                    CreditAmount.SendKeys("5");
                }


            }

            // add Skill-Exchange tags 
            SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            SkillExchange.SendKeys(Keys.Return);

            // Select Active Status 

            if (ActiveOption.Text.Contains(GlobalDefinitions.ExcelLib.ReadData(2, "Active")))
            {
                ActiveOption.Click();

            }

            // Click on Plus Sign to upload wwork sample 

            Upload.Click();

           // Wait
            Thread.Sleep(2000);

            // Run the AUTOIT script to upload file from computer

            Process.Start(MarsResource.AUTOITFilePath + "FileUpload.exe");
            // wait for upload to be done 

            Thread.Sleep(4000);


            // Save the listings


            Save.Click();

        }


        public void dropdown()
        {
            // Select Category dropdown


            CategoryDropDown.Click();
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            //Value1 = "Programming & Tech";
            Value1 = GlobalDefinitions.ExcelLib.ReadData(2, "Category");

            // Value2 = "QA";
            Value2 = GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory");


            //select Category by value
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[text()='" + Value1 + "']"), 10);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[text()='" + Value1 + "']")).Click();


            // Select SubCategory dropdown

            SubCategoryDropDown.Click();


            //select Category by value
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[text()='" + Value2 + "']"), 10);
            GlobalDefinitions.driver.FindElement(By.XPath("//*[text()='" + Value2 + "']")).Click();

        }

        public String Value1;
        public String Value2;
        public string getValue1()
        {
            return Value1;

        }
        public string getValue2()
        {
            return Value2;

        }

        public string readCategory()
        {
            // Read Selected category 

            SelectElement cat = new SelectElement(CategoryDropDown);
            return cat.SelectedOption.Text;


        }

        public string readSubCategory()
        {

            // Read Selected Sub Category 

            SelectElement SubCat = new SelectElement(SubCategoryDropDown);
            return SubCat.SelectedOption.Text;

        }


    }
}
