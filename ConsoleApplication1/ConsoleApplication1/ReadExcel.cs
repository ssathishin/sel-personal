using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Office.Interop.Excel;using System.Threading;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Selenium;

namespace ConsoleApplication1
{

    class ReadExcel
    {
        public void TestUsingExcel()
        {

            try
            {
                    var oXlApplication = new Microsoft.Office.Interop.Excel.Application();
                    var testCasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var oWorkbook = oXlApplication.Workbooks.Open(testCasePath+"/test.xlsx");
                    var oWorksheet = oWorkbook.Sheets["Sheet1"];
                    var range = oWorksheet.UsedRange;
                    Range rows = range.Rows;
                    Range columns = range.Columns;
                    var rowCount = rows.Count;
                    var colCount = columns.Count;
                    var s = new Selenium();
                    
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
                       
                        switch (action)
                        {
                            case "GotoURL" :
                                s.InitiateBrowser(inputValue);
                                break;
                            
                            case "Click":

                                s.WebActions(elementType, elementName).Click();
                                break;

                            case "Clear":

                                s.WebActions(elementType, elementName).Clear();
                                break;

                            case "EnterText":

                                s.WebActions(elementType, elementName).SendKeys(inputValue);
                                break;
                            case "SelectDropDownValue" :

                                new SelectElement(s.WebActions(elementType, elementName)).SelectByText(inputValue);
                                break;
                                
                                /*var select = new SelectElement(driver.FindElement(By.Id(triggerReason)));
                                select.SelectByText(whatpromptedyou);*/

                            case "VerifyTextContains":
                                Assert.That(s.WebActions(elementType,elementName).Text,Is.StringContaining(inputValue));
                                using (var writer = new StreamWriter("c:/log.txt", true))
                                break;
                        }
                }
                oWorkbook.Close();
                oXlApplication.Quit();
                s.driver.Quit();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}
