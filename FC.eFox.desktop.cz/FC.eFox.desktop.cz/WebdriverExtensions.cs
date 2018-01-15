using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace FC.eFox.desktop.cz
{
	public static class WebdriverExtensions
	{
		public static void TakeScreenshot(this IWebDriver driver, string testName)
		{
			string timestamp = DateTime.Now.ToString("MMddHHmm");
			try
			{
				string screenShotLocation = ConfigurationManager.AppSettings["screenshotsLocation"];
				Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
				Directory.CreateDirectory(screenShotLocation);
				screenshot.SaveAsFile(screenShotLocation + testName + "_" + timestamp + ".jpg", OpenQA.Selenium.ScreenshotImageFormat.Jpeg);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message, "Screenshot was not taken");
			}
		}

		public static void WaitForElement(this IWebDriver driver, IWebElement element)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			wait.Until<IWebElement>(ExpectedConditions.ElementToBeClickable(element));

		}
		public static void WaitForScriptToFinish(this IWebDriver driver)
		{
			var javaScriptExecutor = driver as IJavaScriptExecutor;
			var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			wait.Until<bool>(d => Equals(javaScriptExecutor.ExecuteScript("return document.readyState"), "complete"));
		}
		public static void WaitForElementToDisappear(this IWebDriver driver, IWebElement element)
		{
			try
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
				wait.Until(d => Equals(element.Displayed, false));
			}
			catch (WebDriverTimeoutException)
			{
				Console.WriteLine("Given element did not disappear");
				throw;
			}
		}

		public static void WaitForElements(this IWebDriver driver, IList<IWebElement> list)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			wait.Until<bool>(d => (list.Count > 0));
		}

		public static void WaitForPageToLoad(this IWebDriver driver)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
			wait.Until<bool>(d => (driver.FindElement(By.TagName("html")).GetAttribute("class").Contains("fonts-all-loaded"))
			&& (driver.FindElement(By.Id("cookie-disclaimer")).GetAttribute("aria-expanded").Contains("true")));
		}
	}
}
