using NUnit.Framework;
using System;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace MarsFramework
{

    public class ManageListingsTests
    {
       

        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
           

             [Test]
            public void TC_002_01_view_listings()
            {
                ManageListings ManageListings = new ManageListings();
                ShareSkill ShareSkill = new ShareSkill();

                // click on Manage Listings 

                ManageListings.clickOnManageListings();

                // wait 
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[3]"), 10);

                //save the text of listing title which is to be viewed


                String TitleToBeCheckedListing = ManageListings.getTitleOfRowNumber(1);
                Console.WriteLine("Listing to be Checked is : "+TitleToBeCheckedListing);

               
                string Title1 = TitleToBeCheckedListing;


               
                // click on view listing icon

                ManageListings.ClickOnViewListingIcon();

                // check if the correct listing is being viewed by user

                ViewListing viewlistings = new ViewListing();
               
                
                string Title2 = viewlistings.ViewedListingTitle();


                Console.WriteLine("Listing Viewed is : "+ Title2);

                //check if we are on view listing details page

                bool x = Title1 == Title2;
                Assert.True(x);


            }


            [Test]
            public void TC_004_02_edit_listings()
            {

                ManageListings ManageListings = new ManageListings();
                ShareSkill ShareSkill = new ShareSkill();


                // click on Manage Listings 

                ManageListings.clickOnManageListings();
                // Resetting Updated variable value 

                String Updated = "ABC";
                // wait 

                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[3]"), 10);

                //initialize variable 
                Boolean x;

                // check if listing title is "updated Title 1" 

                if (ManageListings.getTitleOfRowNumber(1) != "Updated Title 1")
                {


                    Console.WriteLine(ManageListings.getTitleOfRowNumber(1));

                    //click on update listing icon
                    ManageListings.ClickOnUpdateIcon();


                    // update the listing details

                    ShareSkill.EditListing(1);
                                      
                    GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[3]"), 10);

                    // check listing has been updated successfully

                    Updated = ManageListings.getTitleOfRowNumber(1);
                    Console.WriteLine(Updated);

                      x = (Updated == "Updated Title 1");



                }

                else if (ManageListings.getTitleOfRowNumber(2) != "Updated Title 1")

                {

                    Console.WriteLine(ManageListings.getTitleOfRowNumber(2));
                    //click on update listing icon
                    ManageListings.ClickOnUpdateIcon();


                    // update the listing details

                    ShareSkill.EditListing(2);


                    GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr[1]/td[3]"), 10);



                    // check listing has been updated successfully

                    Updated = ManageListings.getTitleOfRowNumber(1);
                
                    Console.WriteLine(Updated);

                     x = (Updated == "Updated Title 2");



                }
                else
                {
                    Console.WriteLine("Title not Updated");
                    x = false;
                }

                Assert.IsTrue(x);


            }


            [Test]
            public void TC_005_01_delete_listings()
            {

                ManageListings ManageListings = new ManageListings();
                ShareSkill ShareSkill = new ShareSkill();

                // click on Manage Listings tab

                ManageListings.clickOnManageListings();

                // click on delete listing icon 

                ManageListings.DeleteListing();

               
                // check title of listing to be deleted

                string Title = ManageListings.getlistingBeforeDelete();


               
                // check if listing has been deleted

                bool x = false;
              
                GlobalDefinitions.WaitForElement(GlobalDefinitions.driver, By.XPath("//tbody/tr/td[3]"), 10);
                
              //  Thread.Sleep(3000);
                

                ManageListings.ListingsList();
                String[] List = ManageListings.getLinkText();
                Console.WriteLine(List.Length);
                foreach (string str in List)
                {
                    Console.WriteLine(str);
                    if (str == Title)
                    {
                        x = true;

                    }


                }

                // Listing should not be present so variable x should be false 


                Assert.IsFalse(x);

                // if this test fails that may be because two listings are present with same name . 
                // the listing should be unique for this test to pass 


            }


        }
    }
}