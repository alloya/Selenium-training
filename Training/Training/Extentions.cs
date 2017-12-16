using OpenQA.Selenium;

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

		public static bool NumberOfElementsChanged(this IWebDriver driver, By locator, int count)
		{
			return driver.FindElements(locator).Count == count;
		}

		public static bool TextOfElementsChanged(this IWebDriver driver, By locator, string text)
		{
			return driver.FindElement(locator).Text == text;
		}
	}
}
