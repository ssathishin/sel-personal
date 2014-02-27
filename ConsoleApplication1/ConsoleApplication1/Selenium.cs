using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;


namespace ConsoleApplication1

{
    class Selenium
    {
        public IWebDriver driver;


        public void InitiateBrowser(String browser)
        {
            switch (browser)
            {
                case "Firefox" :
                    driver = new FirefoxDriver();
                    break;
                case "Chrome" :
                    driver = new ChromeDriver();
                    break;
                case "InternetExplorer" :
                    driver = new InternetExplorerDriver();
                    break;
                case "Safari" :
                    driver = new SafariDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
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
            Assert.That(driver.FindElement(By.Id(id)).Text, Is.StringContaining(message));
        }


        
        private void VerifyOrderStatus(String receiptNumber)
        {
            int sleepTime = 35000;
            System.Threading.Thread.Sleep(sleepTime);
            driver.Navigate().GoToUrl("https://servicesdev2.worldvision.com.au/orders/" + receiptNumber);
            Assert.That(driver.FindElement(By.CssSelector("pre")).Text, Is.StringContaining("Archived"));
        }

        private bool VerifyText(String textToVerify,By elementBy)
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
                    break;

                case "Name":
                    return wait.Until(elem => driver.FindElement(By.Name(elementName)));
                    break;

                case "LinkText":
                    return wait.Until(elem => driver.FindElement(By.LinkText(elementName)));
                    break;

                case "Css":
                    return wait.Until(elem => driver.FindElement(By.CssSelector(elementName)));
                    break;

                case "Xpath":
                    return wait.Until(elem => driver.FindElement(By.XPath(elementName)));
                    break;

                case "ClassName":
                    return wait.Until(elem => driver.FindElement(By.ClassName(elementName)));
                    break;

                case "PartialLink":

                    return wait.Until(elem => driver.FindElement(By.PartialLinkText(elementName)));
                    break;

                case "TagName":

                    return wait.Until(elem => driver.FindElement(By.TagName(elementName)));
                    break;
            }
            return wait.Until(elem => driver.FindElement(By.Id(elementName)));
        }

        private static void Main(string[] args)
        {
            var r = new ReadExcel();
            r.TestUsingExcel();
            /*using (var writer = new StreamWriter("c:/log.txt", true))
            {
                s.InitiateBrowser(url);
                writer.WriteLine("Verify text : Help people fleeing Syria is : " + s.VerifyText("Help people fleeing Syria", By.CssSelector("h1.gillStitch.syria-header")));
                writer.WriteLine("Verify text : Donate to the Syrian Crisis is : " + s.VerifyText("Donate to the Syrian Crisis", By.CssSelector("h3.syria-sub-header")));
                writer.WriteLine("Verify text : Your gift is : " + s.VerifyText("Your gift", By.CssSelector("h3.wva-orange.form-header")));
                writer.WriteLine("Verify text : I / we will make a single gift of: is : " + s.VerifyText("I / we will make a single gift of:", By.CssSelector("h5")));
                writer.WriteLine("Verify text : $50 could provide one person with food for a month and a mattress to sleep on. is : " + s.VerifyText("$50 could provide one person with food for a month and a mattress to sleep on.", By.CssSelector("label.inline > span")));
                writer.WriteLine("Verify text : $120 could provide a family with a stove to cook meals and help keep warm. is : " + s.VerifyText("$120 could provide a family with a stove to cook meals and help keep warm.", By.XPath("//html[@id='ng-app']/body/div/div[3]/div[2]/form/div[2]/div/div/div[2]/label/span")));
                writer.WriteLine("Verify text : $216 could help a family who have just arrived to a new country get through their first month with essentials such as a blanket, a baby kit, a hygiene kit, a kitchen set and (up to) four mattresses. is : " + s.VerifyText("$216 could help a family who have just arrived to a new country get through their first month with essentials such as a blanket, a baby kit, a hygiene kit, a kitchen set and (up to) four mattresses.", By.XPath("//html[@id='ng-app']/body/div/div[3]/div[2]/form/div[2]/div/div/div[3]/label/span")));
                writer.WriteLine("Verify text : Other amount $ is : " + s.VerifyText("Other amount $ ", By.CssSelector("label.inline.with-field > span")));
                writer.WriteLine("Verify text : Funds raised for an emergency is : " + s.VerifyText("Funds raised for an emergency appeal are applied to the emergency response and for rehabilitation activities in the affected areas. Should the funds raised exceed the amount required to meet the emergency needs of the people in affected areas, or if there are changes in circumstances beyond World Vision's control that limit its ability to use all funds in the affected areas, World Vision will use the excess funds to help people in other life-changing emergency situations.", By.CssSelector("p.fs14")));
                writer.WriteLine("Verify text : Your contact details is : " + s.VerifyText("Your contact details", By.XPath("//html[@id='ng-app']/body/div/div[3]/div[2]/form/div[3]/h3")));
                writer.WriteLine("Verify text : Phone Number 13 32 40 is : " + s.VerifyText("13 32 40",By.Id("footer-phone")));
                writer.WriteLine("Verify text : World vision is a public benevolent is : " + s.VerifyText("World Vision is a Public Benevolent Institution and is endorsed as a Deductible Gift Recipient (DGR) by the Australian Tax Office. It also operates three funds that have DGR status.", By.CssSelector("div.span4 > p")));*/
            }
        }
    }
    