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
	public class Task10 : Base
	{
		[Test]
		public void Task_10()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/en/");

			var link = driver.FindElement(By.CssSelector("#box-campaigns .link ")).GetAttribute("href");

			var name = driver.FindElement(By.CssSelector("#box-campaigns .name ")).Text;

			var oldPrice = driver.FindElement(By.CssSelector("#box-campaigns .regular-price "));

			var newPrice = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price "));

			var oldPriceColor = oldPrice.GetCssValue("color");

			var newPriceColor = newPrice.GetCssValue("color");

			var oldPriceValue = oldPrice.Text;

			var newPriceValue = newPrice.Text;

			var oldPriceSize = oldPrice.GetCssValue("font-size").Substring(0, 2);
			var newPriceSize = newPrice.GetCssValue("font-size").Substring(0, 2);

			Assert.Greater(int.Parse(newPriceSize), int.Parse(oldPriceSize));

			Assert.True(oldPrice.TagName.Equals("s"));
			Assert.True(newPrice.TagName.Equals("strong"));

			var reg = new Regex("([0-9]+");

			var color = reg.Matches(oldPriceColor);

			

			var color1 = reg.Match(oldPriceColor);
		}
	}
}
