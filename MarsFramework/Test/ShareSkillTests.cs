using NUnit.Framework;
using System;
using MarsFramework.Global;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace MarsFramework
{

    public class ShareSkillTests
    {
       

        [TestFixture]
        [Category("Sprint1")]
        class User : Global.Base
        {
           

            [Test]
            public void TC_001_01_Click_ShareSkill()
            {
                ShareSkill ShareSkill = new ShareSkill();


                ShareSkill.clickShareSkillBtn();


                Boolean y = ShareSkill.CheckPageExists();

                Assert.IsTrue(y);


            }
            [Test]
            public void TC_002_01_Add_Title()
            {
                ManageListings ManageListings1 = new ManageListings();
                ShareSkill ShareSkill = new ShareSkill();




                //Click on Manage Listings
                ManageListings1.clickOnManageListings();


               
                //Check Listings already added and assign new value to Listing Title
                
                ManageListings1.ListingsList();



                ShareSkill.clickShareSkillBtn();

                ShareSkill.AddTitleOfNewListing();

                String Added = ShareSkill.getNewAddeditle();            
                String Current = ShareSkill.GetTitleCurrentValue();

                Assert.That(Added== Current, "Expected Title is not equal to Actual Title added");
                
                Console.WriteLine(Current);
                Console.WriteLine(Added);
                
            }

            [Test]
            public void TC_004_01_Select_category()
            {


                ManageListings ManageListings = new ManageListings();
                ShareSkill ShareSkill = new ShareSkill();

                //Click on Skillshare to Add new listing 

                ShareSkill.clickShareSkillBtn();

                ShareSkill.dropdown();


                String Check1 = ShareSkill.getValue1();
                String Check2 = ShareSkill.getValue2();



                Assert.That(Check1 == ShareSkill.readCategory(), "Category Value was not selected");
                Assert.That(Check2 == ShareSkill.readSubCategory(), "Sub-Category Value was not selected");



            }
            [Test]
            public void TC_001_Add_Listing()
            {

                ShareSkill ShareSkill = new ShareSkill();
                ManageListings ManageListingobj = new ManageListings();


                //Click on Manage Listings

                ManageListingobj.clickOnManageListings();



                //Check Listings already added and assign new value to Listing Title
                ManageListingobj.ListingsList();

                // click Share Skill Button 

                ShareSkill.clickShareSkillBtn();

                // add unique title of listing 

                ShareSkill.AddTitleOfNewListing();

                // add rest of the listing details and save

                ShareSkill.AddListing();

                String Title = ShareSkill.getNewAddeditle();
               
                
                bool x= false;

                ManageListingobj.ListingsList();
                String[] List = ManageListingobj.getLinkText();



               for (int i = 0; i < List.Length; i++)
                {
                    if (ManageListings.getTitleOfRowNumber(i+1)== Title)
                    {
                        x = true;
                        break;
                    }
                   
                }
               
               
                // Listing should  be present so variable x should be true 



                Assert.IsTrue(x);



            }


        }
    }
}