using System;
using System.Linq;
using MarsFramework.Config;
using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
     public class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section.nav-secondary > div > a:nth-child(3)")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "//tr[1]/td[8]/div/button[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//tr[1]/td[8]/div/button[3]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//tr[1]/td[8]/div/button[2]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//*[text()='Yes']")]
        private IWebElement clickYesButton { get; set; }

        //Listing Title
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        private IWebElement ListingTitle { get; set; }




        
        public void clickOnManageListings()

        {

            // Click on manage Listings tab

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.CssSelector("#account-profile-section > div > section.nav-secondary > div > a:nth-child(3)"), 10);

            manageListingsLink.Click();


        }

        // click on view listing icon
        public void ClickOnViewListingIcon()
        {
            // click on View Icon (eye)

            view.Click();


        }
        // click on update listing icon
        public void ClickOnUpdateIcon()
        {


            // Click on Edit Listings icon
            edit.Click();


        }



        public String Title;
        // click on delete listing icon and delete listing 
        public void DeleteListing()

        {

            // Perform Delete Operation 
            //  Read The title of listing to be deleted 

                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[2]"), 10);


            Title = ListingTitle.Text;


            // Click on Delete icon

                delete.Click();

                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//*[text()='Yes']"), 10);

            // click Yes button to delete listing

                clickYesButton.Click();


            // Write which listing was deleted 
                Console.WriteLine(Title + " has been deleted");


          
            
        }

        public String getlistingBeforeDelete()
        {
            return Title;
        }



        public String[] linkText = new String[15];

        public string[] getLinkText()
        {
            return linkText;

        }

        public String Title1;

        public string getTitle1()
        {
            return Title1;
        }

        public void ListingsList()
        {


            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[2]"), 10);
           
            //Storing List elements text into String array
            
            for (int i = 0; i < 10; i++)
            {

                try
                {

                    int j = i + 1;

                    String Links = getTitleOfRowNumber(j);

                    linkText[i] = Links;
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

            }


            // save data of excel in collection

            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");

            // check title already added against excel sheet of available title list

            for (int n = 2; n < 10; n++)
            {
                String TitleNew = GlobalDefinitions.ExcelLib.ReadData(n, "Title");

                if (!linkText.Contains(GlobalDefinitions.ExcelLib.ReadData(n, "Title")))
                {

                    k = n;
                    break;

                }
                else
                {
                    Console.WriteLine(TitleNew + " was already added");

                }

            }





        }
       

        public static  int k;
        public static int getVariablek()
        {

            return k;

        }

        public static String getTitleOfRowNumber(int RowNumber)
        {

            // Return the listing title as per  row number (RowNumbr)
            IWebElement Listing = GlobalDefinitions.driver.FindElement(By.XPath("//tbody/tr[" + RowNumber + "]/td[3]"));
            String ListingTitle = Listing.Text;
            return ListingTitle;

        }





    }
}
