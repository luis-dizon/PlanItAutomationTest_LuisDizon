using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanItAssessment
{
    [TestClass]
    public class TestBase
    {
        [TestInitialize]
        public void SetupDriver()
        {
            WebDriverManager.SetDriver();
        }

        [TestCleanup]
        public void CleanupDriver()
        {
            WebDriverManager.CleanDriver();
        }
    }
}
