﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.Base;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver;

        private readonly string _baseUrl = Constants.BaseUrl;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

