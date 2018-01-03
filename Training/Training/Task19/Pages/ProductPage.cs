using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Training
{
	internal class ProductPage : Page
	{
		public ProductPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
			PageFactory.InitElements(driver, this);
		}

		private HeaderCart headerCart;

		[FindsBy(How = How.Name, Using = "add_cart_product")]
		public IWebElement btnAddToCart;


		internal void AddToCart()
		{
			headerCart = new HeaderCart(driver, wait);
			var counter = headerCart.GetNumberOfElementsInCart();
			if (driver.Url.Contains("yellow-duck-p-1"))
			{
				var select = new SelectElement(driver.FindElement(By.Name("options[Size]")));
				select.SelectByIndex(1);
			}
			btnAddToCart.Click();
			wait.Until(d => headerCart.GetNumberOfElementsInCart() != counter);
		}

	}
}
