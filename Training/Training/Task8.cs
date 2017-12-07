using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Training
{
	public class Task8 : Base
	{
		[Test]
		public void Task_8()
		{
			driver.Navigate().GoToUrl("http://localhost/litecart/en/");

			var products = driver.FindElements(By.CssSelector(".product"));
			Console.WriteLine(products.Count);

			foreach (var item in products)
			{
				var sticker = item.FindElements(By.CssSelector(".sticker"));
				
				Assert.True(sticker.Count == 1);
				Assert.True(sticker[0].Displayed);
			}
		}
	}
}
