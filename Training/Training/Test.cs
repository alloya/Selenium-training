using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Training
{
	[TestFixture]
	public class Test : Base
	{

		[Test]
		public void NewTest()
		{
			driver.Navigate().GoToUrl("http://google.com");
			//wait.Until(ExpectedConditions.ElementExists(By.Id("lst-ib")));
			driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
			System.Console.WriteLine("Success");
		}
		
	}
}
