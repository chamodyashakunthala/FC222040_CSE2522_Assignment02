using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSE2522_Assignment02.Page;

namespace CSE2522_Assignment02.Test
{
    [TestFixture]
    public class SampleAppTests
    {
        private IWebDriver driver;
        private SampleAppPage page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            page = new SampleAppPage(driver);
        }

        [Test, Description("TC002_1")]
        public void VerificationOfPage()
        {
            page.NavigateTo();
            Assert.IsTrue(page.AreElementsDisplayed());
        }

        [Test, Description("TC002_2")]
        public void SuccessfulLogin()
        {
            page.NavigateTo();
            page.Login("TestUser", "pwd");
            Assert.AreEqual("Welcome, TestUser!", page.GetStatusText());
        }

        [Test, Description("TC002_3")]
        public void UnsuccessfulLogin()
        {
            page.NavigateTo();
            page.Login("TestUser", "wrong_pass");
            Assert.AreEqual("Invalid username/password", page.GetStatusText());
        }

        [TearDown]
        public void Teardown() => driver.Quit();
    }
}