﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

using System;

namespace Training
{
	[TestFixture]
	public class Base
	{
		public IWebDriver driver { get; set; }
		public WebDriverWait wait { get; set; }

		[SetUp]
		public virtual void BeforeClass()
		{
			//ChromeOptions options = new ChromeOptions();
			//options.SetLoggingPreference(LogType.Browser, LogLevel.All);
			//driver = new ChromeDriver(options);

			driver = new ChromeDriver();

			//InternetExplorerOptions options = new InternetExplorerOptions();
			//options.RequireWindowFocus = true;
			//driver = new InternetExplorerDriver(options);

			//FirefoxOptions options = new FirefoxOptions();
			//options.UseLegacyImplementation = false;
			//options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
			//driver = new FirefoxDriver(options);

			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		[TearDown]
		public virtual void AfterClass()
		{

			driver.Quit();
			driver.Dispose();
			driver = null;
		}
	}
}
