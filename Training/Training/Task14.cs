using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
	public class Task14 : Base
	{
		[Test]
		public void Task_14()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();

			driver.FindElement(By.CssSelector("#content .button")).Click();

			var mainWindow = driver.CurrentWindowHandle;

			var links = driver.FindElements(By.CssSelector(".fa-external-link"));

			foreach (var item in links)
			{
				item.Click();

				wait.Until((d) =>
				{
					var windows = d.WindowHandles;
					foreach (var window in windows)
					{
						if (window != mainWindow)
						{
							return d.SwitchTo().Window(window);
						}
					}
					return null;
				});

				driver.Close();

				driver.SwitchTo().Window(mainWindow);
			}

		}
	}
}
