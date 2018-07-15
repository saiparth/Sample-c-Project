using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nunit
{
	[Binding]
	public   class StepDefinition1 : BaseClass
	{
		[Given(@"I browse the url for ""(.*)"" role")]
		public void GivenIBrowseTheUrlForRole(string userType)
		{
			switch (userType)
			{
				case "admin":
					GotoUrl(ConfigurationManager.AppSettings["BaseUrl"]);
					break;

				default:
					break;
			}
		}
		[Then(@"I should be on ""(.*)"" page")]
		public void ThenIShouldBeOnPage(string ExpectedPagTitle)
		{
			//you can create a excpetion handler to continue on failure
			base.WaitForPageToLoad(ExpectedPagTitle);
			Assert.AreEqual(base.GetTitle(),ExpectedPagTitle);
		}

		[When(@"I click on ""(.*)"" in login page")]
		public void WhenIClickOnInLoginPage(string elementToClick)
		{
			//call the click element method
			new LoginPage().ClickElementsInSignInPage(elementToClick);
		}

		[Then(@"I should be displayed with ""(.*)"" element in sign in page")]
		public void ThenIShouldBeDisplayedWithElementInSignInPage(string element)
		{
			Assert.IsTrue(new LoginPage().IsWebElementDisplayedInLoginPage(element));
		}
		[Then(@"I should be displayed with ""(.*)"" error message for ""(.*)"" field")]
		public void ThenIShouldBeDisplayedWithErrorMessageForField(string ExpectedMessage, string textFieldToAssert)
		{
			Assert.AreEqual(new LoginPage().GetTextOfErrorMessage(textFieldToAssert), ExpectedMessage);
		}
		[AfterTestRun]
		public static void Cleanup()
		{
			quit();
		}


	}
}
