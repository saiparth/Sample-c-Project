using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.Diagnostics;

namespace Nunit
{
	public class BaseClass
	{
		public static IWebDriver wd=BrowserStarter();

		public static IWebDriver BrowserStarter()
		{
			var browser = ConfigurationManager.AppSettings["browser"];
			switch (browser.ToLower())
			{
				case "chrome":
					wd = new ChromeDriver();
					break;

				case "firefox":
					FirefoxDriverService serv = FirefoxDriverService.CreateDefaultService();
					serv.FirefoxBinaryPath = "";
					wd = new FirefoxDriver(serv);
					break;
				default:
					break;
			}
			return wd;
		}

		public static void quit()
		{
			wd.Quit();
		}

		public void GotoUrl(string url)
		{
			wd.Url = url;
		}

		public IWebElement FindById(string id)
		{
			WaitForElement(By.Id(id));
			return wd.FindElement(By.Id(id));
		}
		public IWebElement FindByLinkText(string LinkText)
		{
			WaitForElement(By.LinkText(LinkText));
			return wd.FindElement(By.LinkText(LinkText));
		}
		public IWebElement FindByPartialLinkText(string PartialLinkText)
		{
			WaitForElement(By.PartialLinkText(PartialLinkText));
			return wd.FindElement(By.PartialLinkText(PartialLinkText));
		}
		public IWebElement FindByCssSelector(string CssSelector)
		{
			WaitForElement(By.CssSelector(CssSelector));
			return wd.FindElement(By.CssSelector(CssSelector));
		}
		public IWebElement FindByName(string name)
		{
			WaitForElement(By.Name(name));
			return wd.FindElement(By.Name (name));
		}

		public IWebElement FindByXpath(string xpath)
		{
			WaitForElement(By.XPath(xpath));
			return wd.FindElement(By.XPath(xpath));
		}

		public string GetTitle()
		{
			return wd.Title;
		}

		public void WaitForPageToLoad(string page, int timeout = 60)
		{
			WebDriverWait wait = new WebDriverWait(wd, TimeSpan.FromSeconds(timeout));
			wait.Until( TitleContains(page));
		}
		public static Func<IWebDriver, bool> TitleContains(string title)
		{
			return (driver) => 
			{
				return driver.Title.Contains(title);
			};
		}
		public void WaitForElement(By by, int timeout = 60)
		{
			WebDriverWait wait = new WebDriverWait(wd, TimeSpan.FromSeconds(timeout));
			wait.IgnoreExceptionTypes(typeof( NoSuchElementException));
			wait.Until<IWebElement>((d) =>
			{
				IWebElement element = wd.FindElement(by);
				if (element.Displayed  )
				{
					return element;
				}
				return null;
			});
		}
		public bool IsWebElementDisplayed(By by,int timout=60)
		{
			bool status = false;
			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			while (stopWatch.Elapsed.TotalSeconds < timout&& status==false)
			{
				try
				{
					status = wd.FindElement(by).Displayed;
				}
				catch (Exception)
				{
					status = false;
				}
			}
			return status;
		}
	}
}
