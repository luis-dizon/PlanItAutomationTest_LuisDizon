using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using PlanItAssessment.Extensions;

namespace PlanItAssessment.PageObject
{
    public interface IContactPage
    {
        void Submit();
        bool IsVerifyMessageDisplayed();
        void SetForename(string foreName);
        void SetEmail(string email);
        void SetMessage(string message);
        bool IsMessageSentSuccessful();
    }

    
    internal class ContactPage : PageObjectBase, IContactPage
    {
        //Method
        public void SetForename(string foreName)
        {
            GetForenameInputElement().InputField(foreName);
        }

        public void SetEmail(string email)
        {
            GetEmailInputElement().InputField(email);
        }

        public void SetMessage(string message)
        {
            GetMessageInputElement().InputField(message);
        }

        public void Submit()
        {
            GetSubmitButtonElement().Click();
        }


        public bool IsVerifyMessageDisplayed()
        {
            bool foreName = GetForenameErrorMessage() != null;
            bool email = GetEmailErrorMessage() != null;
            bool message = GetMessageErrorMessage() != null;
            return foreName && email && message;
        }

        public bool IsMessageSentSuccessful()
        {
            return GetSuccessMessage() != null && GetSuccessMessage().Displayed;
        }

        //Elements
        private IWebElement GetForenameInputElement()
        {
            return Driver.FindElement(By.Id("forename"));
        }

        private IWebElement GetEmailInputElement()
        {
            return Driver.FindElement(By.Id("email"));
        }

        private IWebElement GetMessageInputElement()
        {
            return Driver.FindElement(By.Id("message"));
        }

        private IWebElement GetSubmitButtonElement()
        {
            return Driver.FindElement(By.ClassName("btn-contact"));
        }

        private IWebElement GetForenameErrorMessage()
        {
            var elements = Driver.FindElements(By.Id("forename-err"));
            return elements.Count>0 ? elements[0] : null;
        }

        private IWebElement GetEmailErrorMessage()
        {
            var elements = Driver.FindElements(By.Id("email-err"));
            return elements.Count > 0 ? elements[0] : null;
        }

        private IWebElement GetMessageErrorMessage()
        {
            var elements = Driver.FindElements(By.Id("message-err"));
            return elements.Count > 0 ? elements[0] : null;
        }

        private IWebElement GetSuccessMessage()
        {
            return Driver.FindElement(By.ClassName("alert-success"));
        }
    }
}
