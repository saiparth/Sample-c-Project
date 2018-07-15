using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Selenium.Pages
{
	public class GooglePage : BaseClass
	{
		IWebElement SearchBox => FindByName("q");

		
		public void BrowseUrl(string url)
		{
			GotoUrl(url);
		}

		public void typeTextInSearchBox(string text)
		{
			new Actions(wd).MoveToElement(SearchBox).SendKeys(text).SendKeys(Keys.Enter).Build().Perform();
		}

		
	}
}
