/*
 * Perform all functionalities related to TransactionResults Page like:
 * Total Price calculation
 * 
 * */

using EcommerceDemoQA.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace EcommerceDemoQA.PageValidators
{
    public class TransactionResultsPage : BasePage
    {
        private readonly By transactionTotalPriceDisplay = By.XPath(EcommerceResources.TransactionResultsPage_totalPrice);
        private readonly By transactionHeader = By.XPath(EcommerceResources.TransactionResultsPage_transactionHeader);

        public float TotalPrice { get; private set; }
        public float TotalShippingPrice { get; private set; }

        public TransactionResultsPage(IWebDriver driver)
            : base(driver)
        {

        }
        public TransactionResultsPage CalculateTotalPrice()
        {
            string price = Driver.FindElement(transactionTotalPriceDisplay).Text.ToString();
            string[] priceList = price.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            TotalShippingPrice = DemoQAPages.GetPriceFromString(priceList[0].Substring(priceList[0].IndexOf('$')).Replace("$", ""));
            TotalPrice = DemoQAPages.GetPriceFromString(priceList[1].Substring(priceList[1].IndexOf('$')).Replace("$", ""));
            return this;
        }

        public string GetTranasactionHeaderMessage()
        {
           return (Driver.FindElement(transactionHeader).Text.Trim().ToString());
           
        }     
    }
}
