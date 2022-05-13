using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace MarsFramework.Pages
{
    public class ViewListing
    {
        public ViewListing()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        //Title of listing being viewed 
        [FindsBy(How = How.XPath, Using = "//div//div[1]/div[1]/div[2]/h1/span")]
        private IWebElement ViewedTitle { get; set; }

        public string ViewedListingTitle()
        {

            // read title of listing being viewed 
            string t = ViewedTitle.Text;
            return t;


        }
    }
}
