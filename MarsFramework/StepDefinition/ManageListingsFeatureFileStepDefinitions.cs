using System;
using TechTalk.SpecFlow;
using static NUnit.Core.NUnitFramework;
using MarsFramework.Pages;
using MarsFramework.Global;
using OpenQA.Selenium;

namespace MarsFramework
{
    [Binding]
    public class ManageListingsFeatureFileStepDefinitions
    {

        Profile ProfilePage = new Profile();
        ManageListings manageListing = new ManageListings();



        [Given(@"User should be able to Login application")]
        public void GivenUserShouldBeAbleToLoginApplication()
        {
            
            // Check Signout Button is visible
            Boolean DashboardVisible = ProfilePage.LoginSuccessful();
           
            // Login is successful as user can see dashboard

            Assert.AreEqual(true, DashboardVisible);


        }
        [When(@"User should be able to Click on Manage Listing")]
        public void WhenUserShouldBeAbleToClickOnManageListing()
        {
           
            manageListing.clickOnManageListings();


        }

        [Then(@"User should be able to navigate ManageListing page")]
        public void ThenUserShouldBeAbleToNavigateManageListingPage()
        {

            // wait 
            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[3]"), 10);
            
            bool navigationSuccessful = manageListing.ManageListingsPage();

            Assert.AreEqual(true, navigationSuccessful);


        }

        [Given(@"User should be able to navigate ManageListing page")]
        public void GivenUserShouldBeAbleToNavigateManageListingPage()
        {
            manageListing.clickOnManageListings();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[3]"), 10);


        }

        [When(@"User should be able to Click on View Listing icon of <""([^""]*)"">")]
        public void WhenUserShouldBeAbleToClickOnViewListingIconOf(int Rownumber)
        {

           String Title1=  ManageListings.getTitleOfRowNumber(Rownumber);

            ScenarioContext.Current["Data"] = Title1;




        }


        [Then(@"User should be able to view all the information of the selected ShareSkill Listing")]
        public void ThenUserShouldBeAbleToViewAllTheInformationOfTheSelectedShareSkillListing()
        {
            ViewListing viewlistings = new ViewListing();


            string Title2 = viewlistings.ViewedListingTitle();


            Console.WriteLine("Listing Viewed is : " + Title2);

            //check if we are on view listing details page

            var Title1 = (String)ScenarioContext.Current["Data"];

            Assert.AreEqual(Title1, Title2);

        }

        [When(@"User should be able to Click on Edit Listing icon  of <""([^""]*)"">")]
        public void WhenUserShouldBeAbleToClickOnEditListingIconOf(int Rownumber)
        {

            manageListing.ClickOnUpdateIcon();

            GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//div[1]/div/div[2]/div/div[1]/input"), 10);

        }




        [Then(@"User should be able to Edit  the information of the selected skill")]
        public void ThenUserShouldBeAbleToEditTheInformationOfTheSelectedSkill()
        {
            throw new PendingStepException();
        }

        [When(@"User should be able to Click on Delete Listing icon  of <""([^""]*)"">")]
        public void WhenUserShouldBeAbleToClickOnDeleteListingIconOf(int Rownumber)
        {
            throw new PendingStepException();
        }

        [Then(@"User should be able to Delete the selected skill")]
        public void ThenUserShouldBeAbleToDeleteTheSelectedSkill()
        {
            throw new PendingStepException();
        }
    }
}
