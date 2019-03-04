using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProjectBooking
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
      
        public void TestMethod1()
        {
        
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.booking.com");

            driver.FindElementById("ss").SendKeys("New-York");
            driver.FindElement(By.XPath("//button[@data-sb-id='main']")).Click();
            Thread.Sleep(1000);

            string dateOfIdMonth = "M1567296000000"; //Сентябрь 2019     

            IList<IWebElement> listOfMonths = driver.FindElements(By.XPath("//div[@class='c2-month']")); //all months

            if (listOfMonths.FirstOrDefault()?.Displayed == true && dateOfIdMonth.Equals(listOfMonths.First().GetAttribute("data-id")))
            {
                Thread.Sleep(1000);
            }
            else
            {
                foreach (IWebElement item in listOfMonths)
                {
                    if (item.Displayed && dateOfIdMonth.Equals(item.GetAttribute("data-id")))
                    {
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@data-id='M1567296000000']/table[1]/tbody[1]/tr[1]/td[7]")).Click();
                        Thread.Sleep(1000);

                        //driver.FindElement(By.XPath("//div[@class='sb-dates__col --checkout-field']")).Click(); //open Departure date
                        //driver.FindElement(By.XPath("//div[@data-id='M1567296000000']/table[1]/tbody[1]/tr[6]/td[1]")).Click(); //Departure date not interactable 

                        break;
                    }
                  
                    driver.FindElement(By.XPath("//div[@class='c2-button c2-button-further']")).Click(); 
                }

                //var option = driver.FindElement(By.Id("group_adults")); //select group adults
                //var selectElement = new SelectElement(option);
                //var selectAdults.SelectByValue("3");
                //Thread.Sleep(1000);          
            }

            driver.FindElement(By.XPath("//button[@data-sb-id='main']")).Click(); // search






            //string dayOfMonth = "1569801600000"; //Departure date

            //driver.FindElement(By.XPath("//div[@class='sb-dates__col --checkout-field']")).Click();
            //Thread.Sleep(1000);
            //IList<IWebElement> listForDayOfMonth = driver.FindElements(By.XPath("//td[@class='c2-day ']"));
            //if (dayOfMonth.Equals(listForDayOfMonth.First().GetAttribute("data-id")))
            //{
            //    Console.WriteLine("ok");
            //}
            //else
            //{
            //    foreach (IWebElement item in listForDayOfMonth)
            //    {
            //        if (dayOfMonth.Equals(item.GetAttribute("data-id")))
            //        {
            //            Thread.Sleep(1000);
            //            driver.FindElement(By.XPath("//td[@data-id='1569801600000']")).Click();

            //            Thread.Sleep(1000);
            //            driver.FindElement(By.XPath("//button[@data-sb-id='main']")).Click();
            //        }
            //    }
            //}

        }
    }
}

