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
	}
}
