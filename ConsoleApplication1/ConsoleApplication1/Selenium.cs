using System;
using System.Drawing;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;


namespace ConsoleApplication1

{
    internal class Selenium
    {
        public IWebDriver driver;


        public void InitiateBrowser(String browser)
        {
            browser = browser.Replace(" ", string.Empty);
            browser = browser.ToUpper();

            switch (browser)
            {
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    break;
                case "CHROME":
                    driver = new ChromeDriver();
                    break;
                case "INTERNETEXPLORER":
                    driver = new InternetExplorerDriver();
                    break;
                case "SAFARI":
                    driver = new SafariDriver();
                    break;
                case "MOBILEFIREFOX":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Size = new Size(640, 960);
                    break;
                case "MOBILECHROME":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Size = new Size(640, 960);
                    break;
                case "MOBILEINTERNETEXPLORER":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Size = new Size(640, 960);
                    break;
                case "MOBILESAFARI":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Size = new Size(640, 960);
                    break;
                case "PHANTOMJS":
                    driver = new PhantomJSDriver();
                    break;
                case "":
                    return;
            }

            if (!browser.Contains("Mobile"))
            {
                driver.Manage().Window.Maximize();
            }
        }

        public void GoToUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseBrowser()
        {
            driver.Quit();
        }

        private void VerifyOutcome(String id, String message)
        {
            Assert.That(driver.FindElement(By.Id(id)).Text, Does.Contain(message));
        }



        private void VerifyOrderStatus(String receiptNumber)
        {
            int sleepTime = 35000;
            System.Threading.Thread.Sleep(sleepTime);
            driver.Navigate().GoToUrl("https://servicesdev2.worldvision.com.au/orders/" + receiptNumber);
            Assert.That(driver.FindElement(By.CssSelector("pre")).Text, Does.Contain("Archived"));
        }

        private bool VerifyText(String textToVerify, By elementBy)
        {
            try
            {
                Assert.AreEqual(textToVerify, driver.FindElement(elementBy).Text);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;

            }


        }

        public IWebElement WebActions(String elementType, String elementName)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            switch (elementType)
            {
                case "Id":
                    return wait.Until(elem => driver.FindElement(By.Id(elementName)));
                    
                case "Name":
                    return wait.Until(elem => driver.FindElement(By.Name(elementName)));
                    
                case "LinkText":
                    return wait.Until(elem => driver.FindElement(By.LinkText(elementName)));
                    
                case "Css":
                    return wait.Until(elem => driver.FindElement(By.CssSelector(elementName)));
                    
                case "Xpath":
                    return wait.Until(elem => driver.FindElement(By.XPath(elementName)));
                    
                case "ClassName":
                    return wait.Until(elem => driver.FindElement(By.ClassName(elementName)));
                    
                case "PartialLink":
                    return wait.Until(elem => driver.FindElement(By.PartialLinkText(elementName)));
                    
                case "TagName":
                    return wait.Until(elem => driver.FindElement(By.TagName(elementName)));                    
            }
            return wait.Until(elem => driver.FindElement(By.Id(elementName)));
        }

        private static void Main(string[] args)
        {
            var r = new ReadExcel();
            r.TestUsingExcel();
        }
    }
}
    