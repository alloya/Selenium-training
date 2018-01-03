using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Training
{
	internal class MainPage : Page
	{
		public MainPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
			PageFactory.InitElements(driver, this);
		}

		internal void Open()
		{
			driver.Url = "http://localhost/litecart/en/";
		}

		internal ProductPage ClickFirstProduct()
		{
			firstProduct.Click();
			return new ProductPage(driver, wait);
		}

		[FindsBy(How = How.CssSelector, Using = ".product")]
		public IWebElement firstProduct;

		[FindsBy(How = How.ClassName, Using = "quantity")]
		public IWebElement cartCounter;

		

	}
}
