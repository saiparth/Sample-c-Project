using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
namespace Selenium
{
	[Binding]
	public  class StepDefinition : BaseClass
	{
		[Given(@"when I browse the ""(.*)"" URL")]
		public void GivenWhenIBrowseTheURL(string url)
		{
			new GooglePage().BrowseUrl(url);
		}

		[Then(@"I should be on ""(.*)"" page")]
		public void ThenIShouldBeOnPage(string ExpectedTitle)
		{
			WaitForPageToLoad(ExpectedTitle, 30);
			Assert.AreEqual(GetTitle(), ExpectedTitle);
		}
		[When(@"I type ""(.*)"" in searchbox and press enter")]
		public void WhenITypeInSearchboxAndPressEnter(string textToFill)
		{
			new GooglePage().typeTextInSearchBox(textToFill);
		}
		[AfterTestRun]
		public static void cleanUp()
		{
			quit();
		}



	}
}
