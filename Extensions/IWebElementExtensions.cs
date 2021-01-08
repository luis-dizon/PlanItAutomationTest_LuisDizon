using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanItAssessment.Extensions
{
    public static class IWebElementExtensions
    {
        public static void InputField(this IWebElement webElement, string message)
        {
            webElement.Clear();
            webElement.SendKeys(message);
        }
    }
}
