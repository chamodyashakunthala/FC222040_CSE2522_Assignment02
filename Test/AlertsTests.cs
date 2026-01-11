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
    public class AlertsTests
    {
        private IWebDriver driver;
        private AlertsPage alertsPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            alertsPage = new AlertsPage(driver);
        }

        [Test, Order(1)] 
        public void TC004_1_Alerts_Verification()
        {
            alertsPage.NavigateTo();
            NUnit.Framework.Assert.IsTrue(alertsPage.AreButtonsVisible(), "Alert buttons are not appearing.");
        }

        [Test, Order(2)] 
        public void TC004_2_SimpleAlert_Verification()
        {
            alertsPage.NavigateTo();
            alertsPage.ClickAlertButton();

            string alertText = alertsPage.GetAlertTextAndAccept();
            NUnit.Framework.Assert.AreEqual("Today is a working day or less likely a holiday", alertText);
        }

        [Test, Order(3)] 
        public void TC004_3_ConfirmAlert_Verification()
        {
            alertsPage.NavigateTo();

            
            alertsPage.ClickConfirmButton();
            alertsPage.HandleConfirm(true);
            string resultOk = alertsPage.GetAlertTextAndAccept();
            NUnit.Framework.Assert.AreEqual("Yes", resultOk);

          
            alertsPage.ClickConfirmButton();
            alertsPage.HandleConfirm(false);
            string resultCancel = alertsPage.GetAlertTextAndAccept();
            NUnit.Framework.Assert.AreEqual("No", resultCancel);
        }

        [Test, Order(4)] 
        public void TC004_4_PromptAlert_Verification()
        {
            alertsPage.NavigateTo();
            string myInput = "AssignmentDone";

           
            alertsPage.ClickPromptButton();
            alertsPage.EnterTextAndAccept(myInput);
            string result = alertsPage.GetAlertTextAndAccept();
            NUnit.Framework.Assert.AreEqual($"user value {myInput}", result);
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}