using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
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

		[SetUp]
		public virtual void BeforeClass()
		{
			driver = new ChromeDriver();
			//driver = new FirefoxDriver();
			//driver = new InternetExplorerDriver();
			//driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
		}

		[TearDown]
		public virtual void AfterClass()
		{

			driver.Quit();
			driver.Dispose();
		}
	}
}
