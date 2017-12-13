using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			//driver = new ChromeDriver();
			//driver = new FirefoxDriver();

			//InternetExplorerOptions options = new InternetExplorerOptions();
			//options.RequireWindowFocus = true;
			//driver = new InternetExplorerDriver(options);

			FirefoxOptions options = new FirefoxOptions();
			options.UseLegacyImplementation = false;
			options.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
			driver = new FirefoxDriver(options);

			wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			//driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
