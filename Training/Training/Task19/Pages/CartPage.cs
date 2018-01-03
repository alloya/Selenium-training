using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace Training
{
	internal class CartPage : Page
	{
		public CartPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.Id, Using = "order_confirmation-wrapper")]
		public IWebElement table;

		[FindsBy(How = How.CssSelector, Using = ".dataTable tr")]
		public IList<IWebElement> tableRows;

		[FindsBy(How = How.Name, Using = "remove_cart_item")]
		public IWebElement btnRemove;

		internal void DeleteAllProductsFromCart()
		{

			var counter = tableRows.Count - 5;
			do
			{
				wait.Until((IWebDriver d) => d.FindElements(By.CssSelector(".dataTable tr")).Count - 5 == counter);
				btnRemove.Click();
				counter--;
			} while (counter > 0);

			wait.Until(d => d.IsElementNotPresent(By.Id("order_confirmation-wrapper")));
		}

		internal void Open()
		{
			driver.Url = "http://localhost/litecart/en/checkout";
		}
	}
}
