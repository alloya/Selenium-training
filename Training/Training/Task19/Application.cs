using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Training
{
	public class Application : Base
	{
		private CartPage cartPage;
		private MainPage mainPage;
		private ProductPage productPage;
		private HeaderCart headerCart;

		public Application(IWebDriver driver, WebDriverWait wait)
		{
			this.driver = driver;
			this.wait = wait;
			cartPage = new CartPage(driver, wait);
			mainPage = new MainPage(driver, wait);
			productPage = new ProductPage(driver, wait);
			headerCart = new HeaderCart(driver, wait);
		}

		internal void AddElementsToCart(int numberOfElements)
		{
			if (numberOfElements == 0) return;
			for (int i = 0; i < numberOfElements; i++)
			{
				mainPage.Open();
				mainPage.ClickFirstProduct();
				productPage.AddToCart();
			}
		}

		internal string GetNumberOfProductsInCart()
		{
			return headerCart.GetNumberOfElementsInCart();
		}

		internal void DeleteAllFromCart()
		{
			cartPage.Open();
			cartPage.DeleteAllProductsFromCart();
		}
	}
}