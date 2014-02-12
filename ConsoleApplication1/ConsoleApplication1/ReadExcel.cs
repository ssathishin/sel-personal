using System;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;


namespace ConsoleApplication1
{

    class ReadExcel
    {
        String testCasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public void TestUsingExcel()
        {

            try
            {
                    var oXlApplication = new Microsoft.Office.Interop.Excel.Application();
                    
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
                        if (elementType == "Browser")
                        {
                            s.InitiateBrowser(elementName);
                        }


                        switch (action)
                        {
                            case "GotoURL" :
                                s.GoToUrl(inputValue);
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

                            case "VerifyTextContains":
                                Assert.That(s.WebActions(elementType,elementName).Text,Is.StringContaining(inputValue));
                                using (var writer = new StreamWriter("c:/log.txt", true))
                                break;
                        }
                }
                s.driver.Quit();
                oWorkbook.Close();
                oXlApplication.Quit();
            }
            catch (Exception exception)
            {
                using (var writer = new StreamWriter(testCasePath+"/log.txt", true))
                writer.WriteLine(exception);
                Console.WriteLine(exception);
            }
        }
    }
}
