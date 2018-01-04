using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Training
{
	public class Task17 : Base
	{
		[Test]
		public void Task_17()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();

			driver.FindElement(By.LinkText("Catalog")).Click();
			driver.FindElement(By.LinkText("Rubber Ducks")).Click();

			List<string> productLinks = new List<string>();

			var products = driver.FindElements(By.CssSelector(".dataTable .row td:nth-child(3) a"));

			for (int i = 2; i < products.Count-5; i++)
			{
				productLinks.Add(products[i].GetAttribute("href"));
			}

			foreach (var link in productLinks)
			{
				driver.Navigate().GoToUrl(link);
				Assert.IsEmpty(driver.Manage().Logs.GetLog(LogType.Browser).ToList());
			}
		}
	}
}
