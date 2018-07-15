using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Nunit
{
	public class LoginPage : BaseClass
	{

		/// <summary>
		/// this is login page sign in link
		/// </summary>
		IWebElement CustomerSignInLink => base.FindByXpath("(//a[text()='Customer Sign In'])[1]");

		/// <summary>
		/// sign up link
		/// </summary>
		IWebElement SignUpLink => base.FindByXpath("(//a[text()='Not a Customer? Apply Now!'])[1]");

		/// <summary>
		/// next button in sign up page
		/// </summary>
		IWebElement NextButton => base.FindById("ApplicationPersonalComplete");
		#region error mesages
		/// <summary>
		/// next button in sign up page
		/// </summary>
		IWebElement FirstNameErrorMessage => base.FindById("FirstName-error");
		#endregion

		public void ClickElementsInSignInPage(string element)
		{
			switch (element)
			{
				case "customer sign in page link":
					CustomerSignInLink.Click();
					break;
				 
				case "Not a Customer? Apply Now!":
					SignUpLink.Click();
					break;

				case "Next button":
					NextButton.Click();
					break;

				default:
					break;
			}
		}

		public bool IsWebElementDisplayedInLoginPage(string element)
		{
			bool status = false;
			switch (element)
			{
				case "Customer Sign In":
					status = IsWebElementDisplayed(By.XPath("//div[@class='InnerContentCentered']/h1[text()='Customer Sign In']"), 15);
					break;

				case "CASH CENTRAL APPLICATION":
					status = IsWebElementDisplayed(By.XPath("//div[@class='ApplicationHeader']/h1[text()='Cash Central Application']"), 15);
					break;

				case "Personal Information":
					status = IsWebElementDisplayed(By.Id("ApplicationPersonalInformation"), 15);
					break;

				case "Next Button":
					status = IsWebElementDisplayed(By.Id("ApplicationPersonalComplete"), 15);
					break;
				default:
					break;
			}
			
			return status;
		}
		public string GetTextOfErrorMessage(string element)
		{
			string message = "";
			switch (element)
			{
				case "first name":
					message =FirstNameErrorMessage.Text.Trim();
					break;

					//todo other messages
			}
			return message;
		}
	}
}
