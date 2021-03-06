﻿using System;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;



namespace ConsoleApplication1
{

    class ReadExcel
    {
        
        
        String testCasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        Selenium selenium = new Selenium();

        public void TestUsingExcel()
        {

            try
            {
                    var oXlApplication = new Microsoft.Office.Interop.Excel.Application();
                    
                    var oWorkbook = oXlApplication.Workbooks.Open(testCasePath+"/test.xlsx");
                    var oWorksheet = oWorkbook.Sheets["Sheet1"];
                    var range = oWorksheet.UsedRange;
                    Range rows = range.Rows;
                    //Range columns = range.Columns;
                    var rowCount = rows.Count;
                    //var colCount = columns.Count;
                    
                    for (int row = 2; row <= rowCount; row++)
                    {
                        var elementType = (String) oWorksheet.Cells(row, 1).Value;
                        var elementName = (String) oWorksheet.Cells(row, 2).Value;
                        var action = (String) oWorksheet.Cells(row, 3).Value;
                        var inputValue = System.Convert.ToString(oWorksheet.Cells(row, 4).Value);

                        if (!string.IsNullOrEmpty(inputValue))
                        {
                            inputValue = inputValue.ToString();
                        }
                        if (elementType == "Browser" && action == "GotoURL")
                        {
                            selenium.InitiateBrowser(elementName);
                        }

                        if (elementType == string.Empty)
                        {
                            SendEmail(DateTime.Now + " : Test report","If you have not received an exception email the test steps must have reached end of test steps or Element Type is empty");
                        }

                        if (elementType == "Browser" && action == "Close" )
                        {
                            selenium.CloseBrowser();
                        }

                        switch (action)
                        {
                            case "GotoURL" :
                                
                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Go to URL contains : " + elementName + " Value : " + inputValue);
                                selenium.GoToUrl(inputValue);
                                break;

                            case "Close" :
                                
                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Browser close is called : " + elementName + " Value : " + inputValue);
                                selenium.CloseBrowser();
                                break;
                           
                            case "Click":

                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Element being clicked on is : " + elementName + " Value : " + inputValue);
                                selenium.WebActions(elementType, elementName).Click();
                                break;

                            case "Clear":

                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Clearing Element : " + elementName + " Value : " + inputValue);
                                selenium.WebActions(elementType, elementName).Clear();
                                break;

                            case "EnterText":

                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Entering text on : " + elementName + " Value : " + inputValue);
                                selenium.WebActions(elementType, elementName).SendKeys(inputValue);
                                break;

                            case "SelectDropDownValue" :

                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Selecting a value from the dropdown : " + elementName + " Value : " + inputValue);
                                new SelectElement(selenium.WebActions(elementType, elementName)).SelectByText(inputValue);
                                break;

                            case "VerifyTextContains":

                                using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                    writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Verify Text Contains : " + elementName + " Value : " + inputValue);
                                Assert.That(selenium.WebActions(elementType, elementName).Text, Is.StringContaining(inputValue));
                                break;
                        case "EnterKey":

                            using (var writer = new StreamWriter(testCasePath + "/log.txt", true))
                                writer.WriteLine(DateTime.Now + " : Processing row : " + row + " : Verify Text Contains : " + elementName + " Value : " + inputValue);
                            selenium.WebActions(elementType, elementName).SendKeys(Keys.Enter);
                                break;


                    }
                }
                selenium.driver.Quit();
                oWorkbook.Close();
                oXlApplication.Quit();
            }
            catch (Exception exception)
            {
                using (var writer = new StreamWriter(testCasePath+"/log.txt", true))
                    writer.WriteLine(DateTime.Now + " : Error while executing the above line : " + exception);
                using (var writer = new StreamWriter(testCasePath+"/error.txt",true))
                    writer.WriteLine(DateTime.Now + " : Error while executing the above line : " + exception);
                SendEmail(DateTime.Now + " : Exception while running tests. Please check the logs", "Error description : " + exception);
                selenium.CloseBrowser();
            }
        }
        
        
        private void SendEmail(string subjectMessage, string subjectBody)
        {
            var message = new MailMessage();
            /*message.To.Add("sathish.shrinivasulu@worldvision.com.au");
            message.CC.Add("sathish.shrinivasulu@worldvision.com.au");*/
            message.Bcc.Add("sathish.shrinivasulu@worldvision.com.au");
            message.Subject = subjectMessage;
            message.From = new MailAddress("FailedTransactions@worldvision.com.au");
            message.Body = subjectBody;
            var smtp = new SmtpClient("webmail.worldvision.com.au");
            smtp.Send(message);
        }


    }
}
