using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Training
{
	internal class HeaderCart : Page
	{
		public HeaderCart(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
		{
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.ClassName, Using = "quantity")]
		public IWebElement cartCounter;

		internal string GetNumberOfElementsInCart()
		{
			return cartCounter.Text;
		}
	}
}
