using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System.Threading;
using System.Reflection;
using System;
using System.IO;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var chromeOptions = new ChromeOptions();
            var browserLanguage = string.Format("--lang={0}", "en");

            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("--disable-infobars");
            chromeOptions.AddArguments(browserLanguage);
            string driverPath = Path.Combine(Environment.CurrentDirectory, "Drivers");
            string imagePath = Path.Combine(Environment.CurrentDirectory, "Images\\Test_Img.jpg");
            System.Console.WriteLine(driverPath);
            var defaultDriver = new ChromeDriver(driverPath, chromeOptions);
            defaultDriver.Navigate().GoToUrl("http://ourdesigngroup.com/photos/new");
            defaultDriver.SwitchTo().DefaultContent();
            Thread.Sleep(2); // To ensure that the website has been loaded completely

            var titleInput = defaultDriver.FindElementById("photo_title");
            titleInput.SendKeys("Test_Img"); // Input the title

            var imageInput = defaultDriver.FindElementById("photo_image");
            imageInput.SendKeys(imagePath); // Input the image path
            Thread.Sleep(1);
            var submitBtn = defaultDriver.FindElementByCssSelector("input.btn.btn-primary");
            submitBtn.Click(); // Click submit button
            Thread.Sleep(1);

            defaultDriver.Quit();
        }
    }
}
