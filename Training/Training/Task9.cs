using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
	public class Task9 : Base
	{
		[Test]
		public void Task_9_1()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=countries&doc=countries");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();

			var countries = driver.FindElements(By.CssSelector(".row")).Count;

			var countryNames = new List<string>();
			var complexCountries = new List<string>();

			for (var i = 2; i <= countries + 1; i ++)
			{
				var name = driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[5]/a"));
				countryNames.Add(name.Text);

				var counter = driver.FindElement(By.XPath($"//tbody[1]/tr[{i}]/td[6]"));
				if (counter.Text != "0")
				{
					complexCountries.Add(name.GetAttribute("href"));
				}
			}
			Assert.IsNotEmpty(countryNames);

			Assert.True(ListIsSorted(countryNames));

			foreach (var item in complexCountries)
			{
				driver.Navigate().GoToUrl(item);

				var zoneCounter = driver.FindElements(By.XPath("//*[@class='dataTable']//tr")).Count;

				var zoneNames = new List<string>();

				for (var i = 2; i <= zoneCounter - 1; i++)
				{
					var name = driver.FindElement(By.XPath($"//*[@class='dataTable']//tr[{i}]/td[3]"));
					zoneNames.Add(name.Text);
				}
				Assert.IsNotEmpty(zoneNames);

				Assert.True(ListIsSorted(zoneNames));
			}
		}

		[Test]
		public void Task_9_2()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones");
			driver.FindElement(By.Name("username")).SendKeys("admin");
			driver.FindElement(By.Name("password")).SendKeys("admin");
			driver.FindElement(By.Name("login")).Click();

			var countriesLinks = driver.FindElements(By.XPath("//*[@class='row']//td[3]/a"));

			var countryNames = new List<string>();

			foreach (var item in countriesLinks)
			{
				countryNames.Add(item.GetAttribute("href"));
			}

			foreach (var item in countryNames)
			{
				driver.Navigate().GoToUrl(item);

				var list = new List<string>();

				var countries = driver.FindElements(By.XPath("//*[@class='dataTable']//tr")).Count;

				for (int i = 2; i < countries; i++)
				{
					list.Add(driver.FindElement(By.XPath($"//*[@class='dataTable']//tr[{i}]/td[3]/select/option[@selected='selected']")).Text);
				}

				Assert.True(ListIsSorted(list));
			}
		}

		private bool ListIsSorted(List<string> firstList)
		{
			var copy = new List<string>();
			copy.AddRange(firstList);
			copy.Sort();

			return copy.ToString().Equals(firstList.ToString());
		}
	}

	
}
