using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanItAssessment.PageObject
{

    public interface IHomePage
    {
        IContactPage NavigateToContactPage();
        IShopPage NavigateToShopPage();
    }

    internal class HomePage : PageObjectBase, IHomePage
    {
        public HomePage()
        {
            Driver.Navigate().GoToUrl(@"https://jupiter.cloud.planittesting.com/#/home");
        }

        //Methods
        public IContactPage NavigateToContactPage()
        {
            GetContactLinkElement().Click();
            return new ContactPage();
        }

        public IShopPage NavigateToShopPage()
        {
            GetShopPageLinkElement().Click();
            return new ShopPage();
        }

        //Elements
        private IWebElement GetContactLinkElement()
        {
            return Driver.FindElement(By.Id("nav-contact"));
        }    
        
        private IWebElement GetShopPageLinkElement()
        {
            return Driver.FindElement(By.Id("nav-shop"));
        }
    }
}
