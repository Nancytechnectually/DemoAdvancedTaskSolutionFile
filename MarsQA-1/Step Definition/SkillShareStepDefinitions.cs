using System;
using MarsQA_1.Helpers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using MarsQA_1.SpecflowPages.Helpers;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using MarsQA_1.SpecflowPages.Pages;

namespace MarsQA_1
{
    [Binding]
    public class SkillShareStepDefinitions : Driver
    {

        //Object Initialization and Declaration of Variables
        HomePage HomePageObject = new HomePage();
        ManageListings ManageListingObject = new ManageListings();
        SkillShare EditListing = new SkillShare();
        public string Title1;
        public String Title;
        public String[] TitleList;
        
        [Given(@"User is able to Navigate to the Login page")]
        public void GivenUserIsAbleToNavigateToTheLoginPage()
        {

            //check we have Login successfully
            try
            {
                IWebElement logo = driver.FindElement(By.CssSelector("#account-profile-section > div > div.ui.secondary.menu > a"));

            }
            catch(Exception ex)
            {
                Console.WriteLine("Login Unsuccessful");

            }

        }


        [Given(@"user is able to Check Listings already Added on manage Listings page")]
        public void GivenUserIsAbleToCheckListingsAlreadyAddedOnManageListingsPage()
        {


            //Click on Manage Listings
            HomePageObject.ClickOnManageListings();
            


            
        }
        public String TitleKey;
        

        [Given(@"User is able to Click on Share Skill Tab")]
        public void GivenUserIsAbleToClickOnShareSkillTab()
        {

            //Check Listings already added and assign new value to Listing Title
            EditListing.GetExcelValue();

            //Click on Skillshare to Add new listing 

            HomePageObject.ClickonSkillshare();
           


        }



        [When(@"User is able to Add the Details of listing Successfully")]
        public void WhenUserIsAbleToAddTheDetailsOfListingSuccessfully()
        {

           // Add new listing Title
            string SelectedTitle = EditListing.getTitleKey();

            IWebElement Title = driver.FindElement(By.CssSelector("#service-listing-section > div.ui.container > div > form > div.tooltip-target.vertically.padded.ui.grid > div > div.ui.twelve.wide.column > div > div.field > input[type=text]"));
            Title.SendKeys(SelectedTitle);

            // add rest of the listing details and save

            EditListing.AddListing();

        }
       
        [Then(@"User is able to see the added Listing on Manage Listings page")]
        public void ThenUserIsAbleToSeeTheAddedListingOnManageListingsPage()
        {
            
            // click on manage listings
            HomePageObject.ClickOnManageListings();


            // check the title of listing added

            IWebElement CheckTitle = driver.FindElement(By.XPath("//table/tbody/tr/td[3]"));
            
            string SelectedTitle = EditListing.getTitleKey();
            

            // check listing has been added
            Assert.That(CheckTitle.Text== SelectedTitle, "Listing was not added");

        }

        [Given(@"User is able to Click on Manage Listings Tab")]
        public void GivenUserIsAbleToClickOnManageListingsTab()
        {

            // click on manage listing tab
            HomePageObject.ClickOnManageListings();
            
        }

        [When(@"User should be able to click on view listing icon if listing is active")]
        public void WhenUserShouldBeAbleToClickOnViewListingIconIfListingIsActive()
        {


            //save the text of listing title which is to be viewed

            IWebElement ViewListingTitle = driver.FindElement(By.XPath("//table/tbody/tr/td[3]"));
            Title1 = ViewListingTitle.Text;
            // use updated title  to check if listing is updated successfully
            ScenarioContext.Current["TitleKey"] = Title1;

         
            // click on view listing icon

            ManageListingObject.ViewListingIcon();

        }

        [Then(@"User is able to see the Listing details")]
        public void ThenUserIsAbleToSeeTheListingDetails()
        {

            // get value of expected title 

            var ExpectedTitle = (string)ScenarioContext.Current["TitleKey"];
            
            
            Console.WriteLine(ExpectedTitle);

            // check if the correct listing is being viewed by user

            IWebElement body = driver.FindElement(By.TagName("body"));
            Assert.IsTrue(body.Text.Contains(ExpectedTitle));
           
            
            //check if we are on view listing details page
            IWebElement ChatIcon = driver.FindElement(By.XPath("//*[text()= 'Chat']"));
            Assert.That( ChatIcon.Text == "Chat", "Test failed");

        }
        [When(@"User is able to click on update listing icon")]
        public void WhenUserIsAbleToClickOnUpdateListingIcon()
        {

            //click on update listing icon
          ManageListingObject.UpdateIcon(); 
            

        }


        [When(@"User should be able to update existing details of listing Successfully\.")]
        public void WhenUserShouldBeAbleToUpdateExistingDetailsOfListingSuccessfully_()
        {

            // update the listing details
            EditListing.UpdateListing();

        }


        [Then(@"User is able to see the updated Listing on Manage Listings page")]
        public void ThenUserIsAbleToSeeTheUpdatedListingOnManageListingsPage()
        {
            // click on manage listing
            HomePageObject.ClickOnManageListings();


            // check listing has been updated successfully
            IWebElement CheckTitle = driver.FindElement(By.CssSelector("#listing-management-section > div:nth-child(3) > div:nth-child(2) > div:nth-child(1) > table > tbody > tr:nth-child(1) > td:nth-child(3)"));

            Assert.That(CheckTitle.Text == "Updated Title of the Listing", "Listing was not added");

        }

       

        [When(@"User should be able to click on Delete listing icon")]
        public void WhenUserShouldBeAbleToClickOnDeleteListingIcon()
        {
            
            // click on delete listing icon 
            ManageListingObject.DeleteListingIcon();
        }

       
        [Then(@"Listing has been Deleted Successfully")]
        public void ThenListingHasBeenDeletedSuccessfully()
        {

            // click on manage listing tab

            HomePageObject.ClickOnManageListings();
            // check title of listing to be deleted

           Title = ManageListingObject.getlistingBeforeDelete();

            // check if listing has been deleted

            String bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.IsFalse(bodyText.Contains(Title), "Listing was not Deleted");

        }









    }
}
