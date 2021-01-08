using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanItAssessment
{
    public static class WebDriverManager
    {
        public static IWebDriver WebDriver;

        public static IWebDriver SetDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            WebDriver = new ChromeDriver(options);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            return WebDriver; 
        }

        public static void CleanDriver()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }

    }
}
