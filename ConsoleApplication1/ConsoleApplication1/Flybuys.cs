using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Flybuys
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.tellcoles.com.au/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheFlybuysTest()
        {
            driver.Navigate().GoToUrl(baseURL);
            driver.FindElement(By.Id("txtStoreNumber")).Click();
            driver.FindElement(By.Id("txtStoreNumber")).Clear();
            driver.FindElement(By.Id("txtStoreNumber")).SendKeys("0508");
            driver.FindElement(By.Id("txtReceiptNumber")).Clear();
            driver.FindElement(By.Id("txtReceiptNumber")).SendKeys("9509");
            driver.FindElement(By.Id("tbTimeNumber1")).Clear();
            driver.FindElement(By.Id("tbTimeNumber1")).SendKeys("17");
            driver.FindElement(By.Id("tbTimeNumber2")).Clear();
            driver.FindElement(By.Id("tbTimeNumber2")).SendKeys("25");
            driver.FindElement(By.Id("ibStartButton")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-text")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387524_survey_options']/div[4]/div/label/span/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387531_survey_options']/div[8]/label/span/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387534_survey_options']/tbody/tr[2]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387534_survey_options']/tbody/tr[3]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387534_survey_options']/tbody/tr[4]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387534_survey_options']/tbody/tr[5]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387534_survey_options']/tbody/tr[6]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-text")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[2]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[3]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[4]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[5]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[6]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[7]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387542_survey_options']/tbody/tr[8]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[2]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[3]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[4]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[6]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[5]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[7]/td[5]/div")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[7]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[8]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387543_survey_options']/tbody/tr[8]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[2]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[3]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[4]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[5]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[6]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[7]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387544_survey_options']/tbody/tr[8]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[2]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[3]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[4]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[6]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[5]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[7]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387545_survey_options']/tbody/tr[8]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387546_survey_options']/tbody/tr[2]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387546_survey_options']/tbody/tr[3]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387546_survey_options']/tbody/tr[4]/td[5]/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387546_survey_options']/tbody/tr[5]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387546_survey_options']/tbody/tr[6]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387547_survey_options']/tbody/tr[2]/td[5]")).Click();
            driver.FindElement(By.XPath("//table[@id='mainHolder_QuestionAnswers_387547_survey_options']/tbody/tr[3]/td[5]")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387635_survey_options']/div[8]/label/span/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387637_survey_options']/div[8]/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387638_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387639_survey_options']/div[8]/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387640_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387641_survey_options']/div[8]/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387642_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387643_survey_options']/div[8]/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387644_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387645_survey_options']/div[8]/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387646_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387647_survey_options']/div[8]/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387648_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.CssSelector("#cmdNext1 > span.ui-btn-inner.ui-btn-corner-all")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387670_survey_options']/div[9]/label/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387672_survey_options']/div[8]/label/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387673_container']/div/div/label/span/span")).Click();
            driver.FindElement(By.CssSelector("#cmdNext1 > span.ui-btn-inner.ui-btn-corner-all")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387682_survey_options']/div[8]/label/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387683_survey_options']/div[7]/label/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all")).Click();
            driver.FindElement(By.CssSelector("#cmdNext1 > span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387694_survey_options']/div[2]/div/label/span/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387702_survey_options']/div[4]/div/label/span/span[2]")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387707_survey_options']/div[2]/div/label/span")).Click();
            driver.FindElement(By.CssSelector("span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
            driver.FindElement(By.Id("QuestionAnswers_387724")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387724")).SendKeys("6008944876952910");
            driver.FindElement(By.CssSelector("span.ui-btn-text")).Click();
            driver.FindElement(By.Id("QuestionAnswers_387727_2249830_Verbatim")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387727_2249830_Verbatim")).SendKeys("Sathish Kumar");
            driver.FindElement(By.Id("QuestionAnswers_387727_2249831_Verbatim")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387727_2249831_Verbatim")).SendKeys("s_sathish_in@yahoo.com");
            driver.FindElement(By.Id("QuestionAnswers_387728_2249832_Verbatim")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387728_2249832_Verbatim")).SendKeys("0432707679");
            driver.FindElement(By.Id("QuestionAnswers_387728_2249833_Verbatim")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387728_2249833_Verbatim")).SendKeys("Unit 4 4 Bowen Road");
            driver.FindElement(By.Id("QuestionAnswers_387728_2249834_Verbatim")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387728_2249834_Verbatim")).SendKeys("Doncaster East");
            driver.FindElement(By.Id("QuestionAnswers_387728_2249835_Verbatim")).Clear();
            driver.FindElement(By.Id("QuestionAnswers_387728_2249835_Verbatim")).SendKeys("3109");
            driver.FindElement(By.XPath("//div[@id='mainHolder_QuestionAnswers_387731_survey_options']/div/div/label/span/span")).Click();
            driver.FindElement(By.CssSelector("#cmdNext1 > span.ui-btn-inner.ui-btn-corner-all > span.ui-btn-text")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
