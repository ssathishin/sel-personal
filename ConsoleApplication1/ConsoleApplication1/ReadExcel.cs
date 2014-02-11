using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                    var oWorkbook = oXlApplication.Workbooks.Open("c:/test.xlsx");
                    var oWorksheet = oWorkbook.Sheets["Sheet1"];
                    var range = oWorksheet.UsedRange;
                    Range rows = range.Rows;
                    Range columns = range.Columns;
                    var rowCount = rows.Count;
                    var colCount = columns.Count;
                    String url = "https://emergenciesdev2.worldvision.com.au";
                    Selenium s = new Selenium();
                    s.InitiateBrowser(url);

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
                            case "Click":

                                s.WebActions(elementType, elementName).Click();
                                break;

                            case "Clear":

                                s.WebActions(elementType, elementName).Clear();
                                break;

                            case "SendKeys":

                                s.WebActions(elementType, elementName).SendKeys(inputValue);
                                break;
                            case "SelectValue" :

                                new SelectElement(s.WebActions(elementType, elementName)).SelectByText(inputValue);
                                break;
                                
                                /*var select = new SelectElement(driver.FindElement(By.Id(triggerReason)));
                                select.SelectByText(whatpromptedyou);*/
                        }
                }
                    oWorkbook.Close();
            }
            catch (Exception exception)
            {
                
                Console.WriteLine(exception);

            }


            /*Excel.Application xlApplication = new 
            Excel.Workbook xlWorkbook = xlApplication.Workbooks.Open("C:/myexcel.xlsx");
            Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;*/

        }

        
    }
    
}
