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

			var reg = new Regex("[0-9]+");

			var grayColor = reg.Matches(oldPriceColor);
			var redColor = reg.Matches(newPriceColor);

			Assert.True(grayColor[0].Value.Equals(grayColor[1].Value));
			Assert.True(grayColor[0].Value.Equals(grayColor[2].Value));

			Assert.False(redColor[0].Value.Equals("0"));
			Assert.True(redColor[1].Value.Equals("0"));
			Assert.True(redColor[2].Value.Equals("0"));


			driver.Navigate().GoToUrl(link);

			var productName = driver.FindElement(By.ClassName("title")).Text;

			var productOldPrice = driver.FindElement(By.ClassName("regular-price"));
			var productNewPrice = driver.FindElement(By.ClassName("campaign-price"));

			var productOldPriceColor = productOldPrice.GetCssValue("color");
			var productNewPriceColor = productNewPrice.GetCssValue("color");

			var productOldPriceValue = productOldPrice.Text;
			var productNewPriceValue = productNewPrice.Text;

			var productOldPriceSize = productOldPrice.GetCssValue("font-size").Substring(0, 2);
			var productNewPriceSize = productNewPrice.GetCssValue("font-size").Substring(0, 2);

			Assert.Greater(int.Parse(productNewPriceSize), int.Parse(productOldPriceSize));

			Assert.True(productOldPrice.TagName.Equals("s"));
			Assert.True(productNewPrice.TagName.Equals("strong"));

			var newGrayColor = reg.Matches(oldPriceColor);
			var newRedColor = reg.Matches(newPriceColor);

			Assert.True(newGrayColor[0].Value.Equals(newGrayColor[1].Value));
			Assert.True(newGrayColor[0].Value.Equals(newGrayColor[2].Value));

			Assert.False(newRedColor[0].Value.Equals("0"));
			Assert.True(newRedColor[1].Value.Equals("0"));
			Assert.True(newRedColor[2].Value.Equals("0"));

			Assert.True(name == productName);
		}
	}
}
