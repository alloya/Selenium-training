using OpenQA.Selenium;
using System;

namespace Training
{
	public static class Extentions
	{
		public static bool IsElementPresent(this IWebDriver driver, By locator)
		{
			try
			{
				driver.FindElement(locator);
				return true;
			}
			catch (NoSuchElementException ex)
			{
				return false;
			}
		}

		public static bool IsElementNotPresent(this IWebDriver driver, By locator)
		{
			try
			{
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
				return driver.FindElements(locator).Count == 0; ;
			}
			finally
			{
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			}
		}
	}
}
