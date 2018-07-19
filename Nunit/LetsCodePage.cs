using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Nunit
{
	public class LetsCodePage :BaseClass
	{
		//radio buttons
		IWebElement BmwRadioButton => FindById("bmwradio");

		IWebElement BEnzRadioButton => FindById("benzradio");

		IWebElement HondaRadioButton => FindById("hondaradio");

		//dropdown
		IWebElement ddwn => FindById("carselect");

		//checkboxes
		IWebElement BmwCheckbox => FindById("bmwcheck");

		IWebElement BenzCheckBox => FindById("benzcheck");

		IWebElement HondaCheckBox => FindById("hondacheck");

		//switch to window
		IWebElement SwicthToWindoButton => FindById("openwindow");

		string windowName = "Let's Kode It";


		//alert button
		IWebElement SwicthToAlertButton => FindById("alertbtn");

		/// <summary>
		/// bmw,benz,honda
		/// </summary>
		/// <param name="radio"></param>
		public void SelectRadioButton(string radio)
		{
			switch (radio)
			{
				case "bmw":
					BmwRadioButton.Click();
					break;

				case "benz":
					BEnzRadioButton.Click();
					break;

				case "honda":
					HondaRadioButton.Click();
					break;
			}
		}

		/// <summary>
		/// bmw,benz,honda
		/// </summary>
		/// <param name="radio"></param>
		/// <returns></returns>
		public bool IsRadioButtonSelected(string radio)
		{
			bool status = false;
			switch (radio)
			{
				case "bmw":
					status=BmwRadioButton.Selected;
					break;

				case "benz":
					status=BEnzRadioButton.Selected;
					break;

				case "honda":
					status=HondaRadioButton.Selected;
					break;
			}
			return status;
		}

		/// <summary>
		/// BMW,Benz,Honda
		/// </summary>
		/// <param name="option"></param>
		public void selectDropDown(string option)
		{
			SelectElement el = new SelectElement(ddwn);
			el.SelectByValue(option.ToLower());
		}

		public string IsValueSelected( )
		{
			SelectElement el = new SelectElement(ddwn);
			IWebElement SelectedOption = el.SelectedOption;
			return SelectedOption.Text;
		}
		public void SelectcheckBox (string checkBox)
		{
			switch (checkBox)
			{
				case "bmw":
					BmwCheckbox.Click();
					break;

				case "benz":
					BenzCheckBox.Click();
					break;

				case "honda":
					HondaCheckBox.Click();
					break;
			}
		}

		public bool IsCheckBoxSelected(string checkBox)
		{
			bool status = false;
			switch (checkBox)
			{
				case "bmw":
					status = BmwCheckbox.Selected;
					break;

				case "benz":
					status = BenzCheckBox.Selected;
					break;

				case "honda":
					status = HondaCheckBox.Selected;
					break;
			}
			return status;
		}

		public void clickWindowButton()
		{
			SwicthToWindoButton.Click();
			base.SwitchToWindow(windowName);
		}

		public bool IsWindowOpened()
		{
			WaitForWindow(windowName,10);
			if (wd.Title.Equals(windowName))
				return true;
			else
				return false;
		}
		public void closeWindow()
		{
			wd.Close();
			base.SwitchToWindow("Practice | Let's Kode It");
		}
		public void AlertExample()
		{
			SwicthToAlertButton.Click();
			IAlert al = wd.SwitchTo().Alert();
			Thread.Sleep(1000);
			al.Accept();
		}
	}
}
