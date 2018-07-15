using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
namespace Selenium
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
			return wd.FindElement(By.Id(id));
		}

		public IWebElement FindByName(string name)
		{
			return wd.FindElement(By.Name (name));
		}

		public IWebElement FindByXpath(string xpath)
		{
			return wd.FindElement(By.XPath(xpath));
		}

		public string GetTitle()
		{
			return wd.Title;
		}

		public void WaitForPageToLoad(string page,int timeout=60)
		{
			WebDriverWait wait = new WebDriverWait(wd, TimeSpan.FromSeconds(timeout));
			wait.Until(ExpectedConditions.TitleContains(page));
			 
		}
	}
}
