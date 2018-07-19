using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Nunit
{
	[TestClass]
	public class UnitTest1 :BaseClass
	{
		LetsCodePage code = new LetsCodePage();

		[TestMethod]
		public void RadioButton()
		{
			wd.Url = "https://letskodeit.teachable.com/p/practice";
			code.SelectRadioButton("bmw");
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsRadioButtonSelected("bmw"));
			code.SelectRadioButton("benz");
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsRadioButtonSelected("benz"));
			code.SelectRadioButton("honda");
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsRadioButtonSelected("honda"));
		}

		[TestMethod]
		public void checkBoxesDemo()
		{
			code.SelectcheckBox("bmw");
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsCheckBoxSelected("bmw"));
			code.SelectcheckBox("benz");
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsCheckBoxSelected("benz"));
			code.SelectcheckBox("honda");
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsCheckBoxSelected("honda"));
		}

		[TestMethod]
		public void DropDownDemo()
		{
			try
			{
				wd.Url = "https://letskodeit.teachable.com/p/practice";
				
				code.selectDropDown("Benz");
				Thread.Sleep(1000);
				Assert.IsTrue(code.IsValueSelected().Trim().Equals("Benz"));
				code.selectDropDown("BMW");
				Thread.Sleep(1000);
				Assert.IsTrue(code.IsValueSelected().Trim().Equals("BMW"));
				code.selectDropDown("Honda");
				Thread.Sleep(1000);
				Assert.IsTrue(code.IsValueSelected().Trim().Equals("Honda"));
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		[TestMethod]
		[Description("switches to window")]
		public void SwicthToWindow()
		{
			code.clickWindowButton();
			Thread.Sleep(1000);
			Assert.IsTrue(code.IsWindowOpened());
			code.closeWindow();
		}

		[TestMethod]
		public void SwicthToAlertw()
		{
			code.AlertExample();
			Thread.Sleep(1000);
			wd.Quit();
		}

	}
}
