using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Net;
using AventStack.ExtentReports.MarkupUtils;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using OpenQA.Selenium.Interactions;
using System.Data;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace Nunit
{
	[TestClass]
	public class html
	{
		[TestMethod]
		public void TestMethod1()
		{
			var htmlReporter = new ExtentHtmlReporter
						(@"C:\Users\partha\Desktop\dream.html");
			var repo = new ExtentReports();
			repo.AttachReporter(htmlReporter);
			var test = repo.CreateTest("parta");

			var wd = new ChromeDriver();
			wd.Url = "https://www.google.com/";
			HttpWebRequest req = null;
			var tags = wd.FindElementsByTagName("a");

			Dictionary<string, string> li = new Dictionary<string, string>();

			int hi = 0;
			Parallel.ForEach(tags, k =>
			 {
				 hi++;
				 string h = k.GetAttribute("href");
				 try
				 {
					 req = (HttpWebRequest)WebRequest.Create(h);
					 var response = (HttpWebResponse)req.GetResponse();
					 //test.Info(h + "- " + response.StatusCode.ToString());
					 li.Add(h, response.StatusDescription.ToString());
				 }
				 catch (Exception e)
				 {
					 Console.WriteLine(e);

				 }
			 });
			string[][] data = new string[li.Count][];
			int i = 0;
			try
			{
				foreach (KeyValuePair<string, string> item in li)
				{
					data[i] = new string[2] { item.Key, item.Value };
					i++;
				}
				test.Info(MarkupHelper.CreateTable(data));
				test.Info("rama");
			}
			catch (Exception) { }
			//ConvertDictionaryTo2dStringArray(li,test);
			repo.Flush();
			wd.Quit();
		}
		[TestMethod]
		public void CheckHelth()
		{
			 
			var wd = new ChromeDriver();
			wd.Url = "https://www.google.com/";
			HttpWebRequest req = null;
			var tags = wd.FindElementsByTagName("a");

			string h = "";
			var list = new List<string>();
			Parallel.ForEach(tags, k =>
			{
				try
				{
					h = (wd as IJavaScriptExecutor).ExecuteScript("return arguments[0].href", k).ToString();
					req = (HttpWebRequest)WebRequest.Create(h);
					var response = (HttpWebResponse)req.GetResponse();
					list.Add(h + "|" + response.StatusCode);
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			});
			DataTable dat = new DataTable("HTTPS");
			dat.Columns.Add("Page Title", typeof(String));
			dat.Columns.Add("URL", typeof(String));
			dat.Columns.Add("StatusCode", typeof(String));
			foreach (var item in list)
			{
				dat.Rows.Add(wd.Title,  item.Split('|')[0], item.Split('|')[1]);
			}
			var d = ConvertDataTableToHtml(dat);
			string filename = @"dream1.html";
			StreamWriter swXLS = new StreamWriter(filename);
			swXLS.Write(d);
			swXLS.Close();

			wd.Quit();
		}
		/// <summary>
		/// Converts dictionary to 2d string array
		/// </summary>
		/// <param name="Dictionary">Dictionary to be converted</param>
		/// <returns>2D string Array</returns>
		private void ConvertDictionaryTo2dStringArray(Dictionary<string, string> Dictionary, ExtentTest test)
		{

			StringBuilder h = new StringBuilder();
			h.Append("<table> ");
			foreach (KeyValuePair<string, string> item in Dictionary)
			{
				h.Append("<tr><td>" + item.Key + " " + item.Value + "</tr></td>");
			}
			h.Append("</table>");
			test.Info(h.ToString());

		}

		//[TestMethod]
		public void SavePageSource()
		{
			var htmlReporter = new ExtentHtmlReporter
						(@"C:\Users\partha\Desktop\dream.html");
			var repo = new ExtentReports();
			repo.AttachReporter(htmlReporter);
			var test = repo.CreateTest("partha");
			ChromeOptions op = new ChromeOptions();
			op.AddUserProfilePreference("download.default_directory", @"C:\Users\partha\Desktop\sources");
			op.AddUserProfilePreference("intl.accept_languages", "nl");
			op.AddUserProfilePreference("disable-popup-blocking", true);

			IWebDriver wd = new ChromeDriver(op);
			wd.Url = "http://localhost/login.do;jsessionid=5bab65fffoam6";
			Actions ac = new Actions(wd);
			const char character = '\u0053';
			const char characte = '\u0073';
			ac.SendKeys(Keys.Control + Convert.ToString(character) + Keys.Control).Build().Perform();
			wd.FindElement(By.TagName("html")).SendKeys(Keys.Control + Convert.ToString(character) + Keys.Control);
			//test.Info("<a href='"+path+"'>link</a>");
			//repo.Flush();
			wd.Quit();

		}

		[TestMethod]
		public void SaveErrors()
		{
			var htmlReporter = new ExtentHtmlReporter
						(@"C:\Users\partha\Desktop\dream.html");
			var repo = new ExtentReports();
			repo.AttachReporter(htmlReporter);
			var test = repo.CreateTest("partha");
			var wd = new ChromeDriver();
			wd.Url = "file:///E:/webs/automationtesting.in/demo.automationtesting.in/index.html";
			wd.Url = "file:///E:/webs/http___demoqa.com_/demoqa.com/index.html";
			var log = wd.Manage().Logs.GetLog(LogType.Browser);
			//Thread.Sleep(2000);

			foreach (var item in log)
			{
				Console.WriteLine($"level { item.Level} message {item.Message}");
				test.Info($"level { item.Level} message {item.Message}");
			}
			DataTable dat = new DataTable("errors");
			dat.Columns.Add("PagTitle", typeof(String));
			dat.Columns.Add("LogStatus", typeof(String));
			dat.Columns.Add("Error Details", typeof(String));
			foreach (var item in log)
			{
				dat.Rows.Add(wd.Title,$"{ item.Level} ", $"message {item.Message}");
			}
			var d=ConvertDataTableToHtml(dat);
			string filename = (@"C:\Users\partha\Desktop\dream1.html");
			StreamWriter swXLS = new StreamWriter( filename);
			swXLS.Write(d);
			swXLS.Close();
			repo.Flush();
			wd.Quit();



		}
		 
		public static string ConvertDataTableToHtml(DataTable targetTable)
		{
			string htmlString = "";

			if (targetTable == null)
			{
				throw new System.ArgumentNullException("targetTable");
			}

			StringBuilder htmlBuilder = new StringBuilder();

			//Create Top Portion of HTML Document
			htmlBuilder.Append("<html>");
			htmlBuilder.Append("<head>");
			htmlBuilder.Append("<link rel='stylesheet' href='./Mycss.css'>");
			htmlBuilder.Append("<title>");
			htmlBuilder.Append("Page-");
			htmlBuilder.Append("Dev report");
			htmlBuilder.Append("</title>");
			htmlBuilder.Append("</head>");
			htmlBuilder.Append("<body>");
			htmlBuilder.Append(
"<table border=\"1px\" cellpadding=\"5\" cellspacing=\"0\" hold=\" / > htmlBuilder.Append(\" style=\"border: solid 1px Black; font - size: small; \">");

			//Create Header Row
			htmlBuilder.Append("<tr align=\"left\" valign=\"top\">");
			int i = 3;
			foreach (DataColumn targetColumn in targetTable.Columns)
			{
				if (i >=3)
				{
					htmlBuilder.Append("<th align='left' valign='top'>");
					htmlBuilder.Append(targetColumn.ColumnName);
					htmlBuilder.Append("</th>");
				}
				else
				{
					htmlBuilder.Append("<td align='left' valign='top'>");
					htmlBuilder.Append(targetColumn.ColumnName);
					htmlBuilder.Append("</td>");
				}
				i++;
			}

			htmlBuilder.Append("</tr>");

			//Create Data Rows
			foreach (DataRow myRow in targetTable.Rows)
			{
				htmlBuilder.Append("<tr align='left' valign='top'>");

				foreach (DataColumn targetColumn in targetTable.Columns)
				{
					htmlBuilder.Append("<td align='left' valign='top'>");
					htmlBuilder.Append(myRow[targetColumn.ColumnName].ToString());
					htmlBuilder.Append("</td>");
				}

				htmlBuilder.Append("</tr>");
			}

			//Create Bottom Portion of HTML Document
			htmlBuilder.Append("</table>");
			htmlBuilder.Append("</body>");
			htmlBuilder.Append("</html>");

			//Create String to be Returned
			htmlString = htmlBuilder.ToString();

			return htmlString;
		}
	}
}
