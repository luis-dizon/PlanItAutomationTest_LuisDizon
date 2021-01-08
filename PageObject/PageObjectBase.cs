using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanItAssessment.PageObject
{
    internal class PageObjectBase
    {
        protected IWebDriver Driver => WebDriverManager.WebDriver;
    }
}
