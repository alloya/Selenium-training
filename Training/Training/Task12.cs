using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Linq;

namespace Training
{
	public class Task12 : Base
	{
		[Test]
		public void Task_12()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=catalog&doc=catalog");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();

			var tableRows = driver.FindElements(By.ClassName("row")).Count;

			driver.FindElement(By.CssSelector("#content div a:last-child")).Click();

			var navigationMenu = driver.FindElements(By.CssSelector(".index li"));

			driver.FindElement(By.Name("name[en]")).SendKeys("test");

			var image = driver.FindElement(By.Name("new_images[]"));
			var path = AppDomain.CurrentDomain.BaseDirectory; 
			path = Path.Combine(path.Remove(path.Length - 10), "test.png");
			image.SendKeys(path);

			navigationMenu[1].Click();

			wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("manufacturer_id")));
			var select = new SelectElement(driver.FindElement(By.Name("manufacturer_id")));
			select.SelectByIndex(1);

			navigationMenu[3].Click();

			
			wait.Until(ExpectedConditions.ElementIsVisible(By.Name("purchase_price")));
			var price = driver.FindElement(By.Name("purchase_price"));
			price.Clear();
			price.SendKeys("100");

			var currency = new SelectElement(driver.FindElement(By.Name("purchase_price_currency_code")));
			currency.SelectByIndex(2);

			driver.FindElement(By.Name("save")).Click();

			var updatedTableRows = driver.FindElements(By.ClassName("row")).Count;

			Assert.True((tableRows + 1) == updatedTableRows);
		}
	}
}
