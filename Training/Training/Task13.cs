using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Training
{
	public class Task13 : Base
	{
		[Test]
		public void Task_13()
		{
			IWebElement cartCounter;
			for (int i = 1; i <= 3; i++)
			{
				driver.Navigate().GoToUrl("http://localhost/litecart/en/");
				driver.FindElement(By.CssSelector(".product")).Click();
				if (driver.Url.Contains("yellow-duck-p-1"))
				{
					var select = new SelectElement(driver.FindElement(By.Name("options[Size]")));
					select.SelectByIndex(1);
				}
				driver.FindElement(By.Name("add_cart_product")).Click();
				cartCounter = driver.FindElement(By.ClassName("quantity"));
				wait.Until(ExpectedConditions.TextToBePresentInElement(cartCounter, i.ToString()));
			}

			driver.FindElement(By.Id("cart")).Click();

			if (driver.IsElementPresent(By.Id("order_confirmation-wrapper")))
			{
				var counter = driver.FindElements(By.CssSelector(".dataTable tr")).Count - 5;
				do
				{
					wait.Until((IWebDriver d) => d.FindElements(By.CssSelector(".dataTable tr")).Count - 5 == counter);

					driver.FindElement(By.Name("remove_cart_item")).Click();

					counter--;
				} while (counter > 0);

			}

		}

		
	}
}
