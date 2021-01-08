using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlanItAssessment.PageObject;
using PlanItAssessment.Enumerations;
namespace PlanItAssessment
{
    [TestClass]
    public class PracticeTest : TestBase
    {
        [TestMethod]
        public void VerifyErrorMessage_UITest()
        {
            var homePage = new HomePage();
            IContactPage contactPage = homePage.NavigateToContactPage();
            contactPage.Submit();
            Assert.IsTrue(contactPage.IsVerifyMessageDisplayed(), "The error message is not displayed");
            contactPage.SetForename("Luis");
            contactPage.SetEmail("luis.pot.dizon@gmail.com");
            contactPage.SetMessage("This is a test message");
            Assert.IsFalse(contactPage.IsVerifyMessageDisplayed(), "The error message is still displayed displayed");
        }

        [TestMethod]
        public void VerifySuccessfulMessage_UI_Test()
        {
            var homePage = new HomePage();
            IContactPage contactPage = homePage.NavigateToContactPage();
            contactPage.SetForename("Luis");
            contactPage.SetEmail("luis.pot.dizon@gmail.com");
            contactPage.SetMessage("This is a test message");
            contactPage.Submit();
            Assert.IsTrue(contactPage.IsMessageSentSuccessful(), "Success message is not displayed");
        }

        [TestMethod]
        public void VerifyTeddyBearPrice()
        {
            //1. From the home page go to shop page
            IHomePage homePage = new HomePage();
            IShopPage shopPage = homePage.NavigateToShopPage();
            //2.Validate “Teddy Bear” costs $12.99
            Assert.AreEqual("$12.99", shopPage.GetPrice(Products.TeddyBear), "Price is wrong");            
        }
    }
}
