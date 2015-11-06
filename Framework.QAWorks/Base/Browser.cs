using System;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.Extensions;
using Framework.QAWorks.Base.Helpers;

namespace Framework.QAWorks.Base
{
    public class Browser
    {
        public static IWebDriver Driver { get; private set; }

        public static void NavigateTo(string url)
        {            
            if (Driver == null)
            {
                Initialize();
            }

            Driver.Navigate().GoToUrl(url);
            Sync.WaitFor(30, _ => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void TakeScreenshotOnException(string title)
        {
            string timestamp = DateTime.Now.ToString("dd-MMM-yyyy hh.mm.ss");
            var currentDir = Environment.CurrentDirectory;
            const string folderName = "\\ErrorScreenshots";
            Directory.CreateDirectory(currentDir + folderName);
            Driver.TakeScreenshot().SaveAsFile(currentDir + folderName + "\\" + title + " - " + timestamp + ".png", ImageFormat.Png);
        }
        
        public static void Initialize(string inputConfig = null)
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Window.Maximize();
        }

        public static void MaximizeBrowser()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void Quit()
        {
            if (Driver == null)
            {
                return;
            }
            Driver.Quit();
            if (IsAlertPresent())
            {
                Driver.SwitchTo().Alert().Accept();
            }
            Driver = null;
        }
        
        public static bool IsAlertPresent()
        {
            try
            {
                Driver.SwitchTo().Alert();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ExecuteScript(string script)
        {
            (Driver as IJavaScriptExecutor).ExecuteScript(script);
        }
    }
}