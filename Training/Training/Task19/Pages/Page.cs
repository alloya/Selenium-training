using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Training
{
	internal class Page : Base
	{
		public Page(IWebDriver driver, WebDriverWait wait)
		{
			this.driver = driver;
			this.wait = wait;

		}
	}
}
