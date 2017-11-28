using NUnit.Framework;
using OpenQA.Selenium;

namespace Training
{
	[TestFixture]
	public class Task1 : Base
	{
		[Test]
		public void Task1_1()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();
		}


	}
}
