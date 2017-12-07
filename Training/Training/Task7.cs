using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Training
{
	public class Task7 : Base
	{
		[Test]
		public void Task_7()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();

			var elementsCount = driver.FindElements(By.CssSelector("#box-apps-menu-wrapper li")).Count;
			for (var i = 1; i <= elementsCount; i++)
			{
				var element = driver.FindElement(By.XPath($"//li[@id='app-'][{i}]"));
				element.Click();

				if (driver.IsElementPresent(By.CssSelector(".docs li")))
				{
					var subCount = driver.FindElements(By.CssSelector(".docs li")).Count;
					for (var k = 1; k <= subCount; k++)
					{
						var subFolder = driver.FindElement(By.XPath($"//ul[@class='docs']/li[{k}]"));
						subFolder.Click();
						Assert.True(driver.FindElement(By.CssSelector("h1")).Displayed);
						Console.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
					}
				}

				
			}
		}
	}
}
