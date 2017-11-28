using NUnit.Framework;
using OpenQA.Selenium;

namespace Training
{
	[TestFixture]
	public class Test : Base
	{

		[Test]
		public void NewTest()
		{
			driver.Navigate().GoToUrl("http://google.com");
			driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
		}

	}
}
