using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Training
{
	[TestFixture]
	public class Test
	{
		private IWebDriver driver;

		[SetUp]
		public void SetUp()
		{
			driver = new ChromeDriver();
		}

		[Test]
		public void NewTest()
		{
			driver.Navigate().GoToUrl("http://google.com");
			driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
		}

		[TearDown]
		public void Dispose()
		{
			driver.Quit();
		}
	}
}
