using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Training
{
	public class Task11 : Base
	{
		[Test]
		public void Task_11()
		{
			var email = $"{GenerateName()}@test.com";

			driver.Navigate().GoToUrl("http://localhost/litecart/en/create_account");

			driver.FindElement(By.Name("firstname")).SendKeys("test");
			driver.FindElement(By.Name("lastname")).SendKeys("test");
			driver.FindElement(By.Name("address1")).SendKeys("test");
			driver.FindElement(By.Name("city")).SendKeys("test");
			driver.FindElement(By.Name("postcode")).SendKeys("12345");
			driver.FindElement(By.Name("email")).SendKeys(email);
			driver.FindElement(By.Name("phone")).SendKeys("12345");

			driver.FindElement(By.ClassName("select2-selection__rendered")).Click();
			driver.FindElement(By.ClassName("select2-search__field")).SendKeys("United States");
			driver.FindElement(By.CssSelector(".select2-results ul li:first-child")).Click();

			driver.FindElement(By.Name("password")).SendKeys("test");
			driver.FindElement(By.Name("confirmed_password")).SendKeys("test");
			driver.FindElement(By.Name("create_account")).Click();

			driver.FindElement(By.LinkText("Logout")).Click();

			driver.FindElement(By.Name("email")).SendKeys(email);
			driver.FindElement(By.Name("password")).SendKeys("test");
			driver.FindElement(By.Name("login")).Click();

			driver.FindElement(By.LinkText("Logout")).Click();
		}

		private static string GenerateName()
		{
			var guid = Guid.NewGuid().ToString();
			string uniqueName = Regex.Replace(guid, "[0-9\\-]", String.Empty);
			return uniqueName;
		}
	}
}
