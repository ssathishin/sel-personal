﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using ConsoleApplication1;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApplication1

{
    class Selenium
    {
        public IWebDriver driver;

        private void FillContactDetails(String whatpromptedyou, String triggerReason, String ContactType)                                   
        {
            if (ContactType == "Individual")
            {
                driver.FindElement(By.Id("firstName")).SendKeys("Sathish");
                driver.FindElement(By.Id("lastName")).SendKeys("Kumar");
            }

            if (ContactType == "Organisation")
            {
                driver.FindElement(By.Id("organisation")).Click();
                driver.FindElement(By.Id("organisationName")).SendKeys("Organisation");
                driver.FindElement(By.Id("contactName")).SendKeys("Contact Name");
            }

            driver.FindElement(By.Id("email")).SendKeys("sathish.shrinivasulu@worldvision.com.au");
            driver.FindElement(By.Id("phoneNumber")).SendKeys("0412341234");
            driver.FindElement(By.Id("address")).SendKeys("1 Vision Drive, BURWOOD EAST  VIC  3151");

            if (IsElementVisible(triggerReason))
            {
                var select = new SelectElement(driver.FindElement(By.Id(triggerReason)));
                select.SelectByText(whatpromptedyou);
            }
            driver.FindElement(By.Id("nextButton")).Click();
        }


        private bool IsElementVisible(String elementId)
        {
            try
            {
                driver.FindElement(By.Id(elementId));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

       
        



        public void InitiateBrowser(String url)
        {
            driver = new FirefoxDriver();
            //driver = new ChromeDriver();
            //driver = new InternetExplorerDriver();
            //driver = new AndroidDriver();
            //driver = new SafariDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
            
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
        


        private void TestSouthSudan(String url, String dollarHandle,String triggerOption, String contactType)
        {
            InitiateBrowser(url);
            driver.FindElement(By.Id(dollarHandle)).Click();
            if (dollarHandle == "optionCustom")
            {
                driver.FindElement(By.Id("customAmount")).SendKeys("99999");
            }
            FillContactDetails(triggerOption, "triggerReason", contactType);
            driver.Quit();
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            switch (elementType)
            {
                case "Id":
                    //return wait.Until(driver.FindElement(By.Id(elementName)));
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

        private void TestGlc(String url)
        {

            var glcDevUrl = "http://cmsdev2.worldvision.com.au/glc/default.aspx";
            var glcTestUrl = "http://cmstest2.worldvision.com.au/glc/default.aspx";
            var glcstageUrl = "http://cmsstage.worldvision.com.au/glc/default.aspx";
            var glcUrlToTest = "";

            switch (url)
            {
                case "dev" :
                    glcUrlToTest = glcDevUrl;
                    break;
                case "stage" :
                    glcUrlToTest = glcstageUrl;
                    break;
                case "test" :
                    glcUrlToTest = glcTestUrl;
                    break;
            }
            
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    InitiateBrowser(glcUrlToTest);
                    WebActions("Id", "btn-cta").Click();
                    WebActions("LinkText","QLD").Click();
                    WebActions("LinkText","Register now").Click();
                    WebActions("Id","GlcRegistrationViewModel_NumberOfStudents").Clear();
                    WebActions("Id","GlcRegistrationViewModel_NumberOfStudents").SendKeys("99");
                    new SelectElement(WebActions("Id","BasicSupporterInformationViewModel_Title")).SelectByText("Miss");
                    WebActions("Id","BasicSupporterInformationViewModel_FirstName").SendKeys("Sarah");
                    WebActions("Id","BasicSupporterInformationViewModel_LastName").SendKeys("Bell");
                    WebActions("Id","PhoneNumberViewModel.PhoneNumberType_2").Click();
                    WebActions("Id", "PhoneNumberViewModel_PhoneNumber").SendKeys("9999999999");
                    WebActions("Id", "EmailAddressViewModel_EmailAddress").SendKeys("sathish.shrinivasulu@worldvision.com.au");
                    WebActions("Id", "EmailAddressViewModel_ConfirmEmailAddress").SendKeys("sathish.shrinivasulu@worldvision.com.au");
                    WebActions("Id","NextButton").Click();
                    Thread.Sleep(1000);
                    WebActions("Id","School").SendKeys("hill");
                    Thread.Sleep(1000);
                    WebActions("LinkText","Canberra Grammar School, Red Hill, RED HILL").Click();
                    Thread.Sleep(1000);
                    WebActions("Id","NextButton").Click();
                    WebActions("Id","PaymentType_0").Click();
                    WebActions("Id","CreditCardAuthorisation").Click();
                    WebActions("Id","ReadTermsAndConditions").Click();
                    WebActions("Id","NextButton").Click();
                    WebActions("Name", "CardNum").SendKeys("4111111111111111");
                    WebActions("Name","ExMnth").SendKeys("12");
                    WebActions("Name","ExYr").SendKeys("15");
                    WebActions("Name", "NmeCard").SendKeys("Sathish Kumar");
                    WebActions("Id","Cvc2").SendKeys("1234");
                    WebActions("Id","submitImageButton").Click();
                    Thread.Sleep(3000);
                    Assert.True(WebActions("Css","h4").Text.StartsWith("W5"));
                    driver.Quit();

                }
                catch (Exception errException)
                {
                    Console.WriteLine(errException.Message);
                }
            }
        }

        private void Test40HourFamine(String testEnvironment)
        {
            var urlToTest = "";
            var devUrl = "http://cmsdev2.worldvision.com.au/40hourfamine.aspx";
            var testUrl = "http://cmstest2.worldvision.com.au/40hourfamine.aspx";
            var stageUrl = "http://cmsstage.worldvision.com.au/40hourfamine.aspx";
            var prodUrl = "http://worldvision.com.au/40hourfamine.aspx";

            switch (testEnvironment)
            {
                case "dev":
                    urlToTest = devUrl;
                    break;
                case "test":
                    urlToTest = testUrl;
                    break;
                case "stage":
                    urlToTest = stageUrl;
                    break;
                case "production":
                    urlToTest = prodUrl;
                    break;

            }
        }


        private static void Main(string[] args)
        {
                

            var s = new Selenium();
            var r = new ReadExcel();
            r.TestUsingExcel();
            //s.TestGlc("dev");
            //s.Test40HourFamine("dev");


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
                writer.WriteLine("Verify text : World vision is a public benevolent is : " + s.VerifyText("World Vision is a Public Benevolent Institution and is endorsed as a Deductible Gift Recipient (DGR) by the Australian Tax Office. It also operates three funds that have DGR status.", By.CssSelector("div.span4 > p")));
                s.driver.Quit();
            }




                s.TestSouthSudan(url, "option50", "Word of Mouth", "Organisation");
                s.TestSouthSudan(url, "option120", "World Vision Website", "Organisation");
                s.TestSouthSudan(url, "option216", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "optionCustom", "Media", "Organisation");

                s.TestSouthSudan(url, "option50", "Word of Mouth", "Individual");
                s.TestSouthSudan(url, "option120", "World Vision Website", "Individual");
                s.TestSouthSudan(url, "option216", "At a Church event", "Individual");
                s.TestSouthSudan(url, "optionCustom", "Media", "Individual");


                url = "https://emergenciesdev2.worldvision.com.au/#/syria-partners";
                s.TestSouthSudan(url, "option500", "Word of Mouth", "Organisation");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Organisation");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "optionCustom", "Media", "Organisation");

                s.TestSouthSudan(url, "option500", "Word of Mouth", "Individual");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Individual");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "optionCustom", "Media", "Individual");

                url = "https://emergenciesdev2.worldvision.com.au/#/typhoon-haiyan";
                s.TestSouthSudan(url, "option500", "Word of Mouth", "Organisation");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Organisation");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "optionCustom", "Media", "Organisation");

                s.TestSouthSudan(url, "option500", "Word of Mouth", "Individual");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Individual");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "optionCustom", "Media", "Individual");

                url = "https://emergenciesdev2.worldvision.com.au/#/typhoon-haiyan-baltazar";
                s.TestSouthSudan(url, "option500", "Word of Mouth", "Organisation");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Organisation");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "option7500", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "optionCustom", "Media", "Organisation");

                s.TestSouthSudan(url, "option500", "Word of Mouth", "Individual");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Individual");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "option7500", "At a Church event", "Individual");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "optionCustom", "Media", "Individual");

                url = "https://emergenciesdev2.worldvision.com.au/#/disaster-ready-donate";
                s.TestSouthSudan(url, "option500", "Word of Mouth", "Organisation");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Organisation");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "optionCustom", "Media", "Organisation");

                s.TestSouthSudan(url, "option500", "Word of Mouth", "Individual");
                s.TestSouthSudan(url, "option1000", "World Vision Website", "Individual");
                s.TestSouthSudan(url, "option5000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "option10000", "At a Church event", "Individual");
                s.TestSouthSudan(url, "optionCustom", "Media", "Individual");

                url = "https://emergenciesdev2.worldvision.com.au/#/south-sudan-donate";
                s.TestSouthSudan(url, "option50", "Word of Mouth", "Individual");
                s.TestSouthSudan(url, "option100", "World Vision Website", "Individual");
                s.TestSouthSudan(url, "option150", "At a Church event", "Individual");
                s.TestSouthSudan(url, "optionCustom", "Media", "Individual");

                s.TestSouthSudan(url, "option50", "Word of Mouth", "Organisation");
                s.TestSouthSudan(url, "option100", "World Vision Website", "Organisation");
                s.TestSouthSudan(url, "option150", "At a Church event", "Organisation");
                s.TestSouthSudan(url, "optionCustom", "Media", "Organisation");*/

        }
        }
    }

