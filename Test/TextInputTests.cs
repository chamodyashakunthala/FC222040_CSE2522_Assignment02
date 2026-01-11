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
    public class TextInputTests
    {
        private IWebDriver driver;
        private TextInputPage textInputPage;

        [SetUp] 
        public void Setup()
        {
           
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

           
            textInputPage = new TextInputPage(driver);
        }

        [Test]
        [TestCase("MyNewButton")] 
        public void TC001_1_TextInput_Verification(string buttonName)
        {
           
            textInputPage.NavigateTo();

            
            Assert.IsTrue(textInputPage.IsInputDisplayed(), "Text input box should be visible.");

            
            textInputPage.EnterButtonText(buttonName);
            textInputPage.ClickButton();

            
            string actualText = textInputPage.GetButtonText();
            Assert.AreEqual(buttonName, actualText, "Button text did not change correctly.");
        }

        [TearDown] 
        public void TearDown()
        {
          
            driver.Quit();
            driver.Dispose();
        }
    }
}