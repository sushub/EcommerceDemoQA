/*
 * Perform all functionalities related to checkout Page like:
 * 1>completing the orderform during checkout
 * 2>Checking the error messages during process of check out
 * 3>Removing items from cart during checkout
 * 
 * */

using EcommerceDemoQA.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace EcommerceDemoQA.PageValidators
{
  public class CheckoutPage:BasePage
    {
        private readonly By removeForm = By.XPath(EcommerceResources.CheckoutPage_remove); 
        private readonly By cartContent = By.XPath(EcommerceResources.CheckoutPage_emptyCartContent); 
        private readonly By continueButton = By.XPath(EcommerceResources.CheckoutPage_continue);
        private readonly By selectCountry = By.XPath(EcommerceResources.CheckoutPage_selectCountry);
        private readonly By calculateButton = By.XPath(EcommerceResources.CheckoutPage_calculatePrice);    
        private readonly By emailAddress = By.XPath(EcommerceResources.CheckoutPage_emailaddress);
        private readonly By firstName = By.XPath(EcommerceResources.CheckoutPage_firstName);
        private readonly By lastName = By.XPath(EcommerceResources.CheckoutPage_lastName);
        private readonly By address = By.XPath(EcommerceResources.CheckoutPage_address);
        private readonly By city = By.XPath(EcommerceResources.CheckoutPage_city);
        private readonly By billingcountry = By.XPath(EcommerceResources.CheckoutPage_country);
        private readonly By phone = By.XPath(EcommerceResources.CheckoutPage_phone);
        private readonly By billingSameAsShipping = By.XPath(EcommerceResources.CheckoutPage_shippingSameasBilling);
        private readonly By purchase = By.XPath(EcommerceResources.CheckoutPage_orderPurchase);   
        

        public CheckoutPage(IWebDriver driver)
            : base(driver)
        {
            Driver.Url = DemoQAPages.GetPageUrl("CheckoutPage");
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            if (!Driver.Title.Equals("Checkout | Online store", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new InvalidDataException("This is not iPhone order page");

            }
        }

        public void RemoveAllItems()
        {
            int cartProductsRowsCount = Driver.FindElements(removeForm).Count;
            for (int i = 0; i < cartProductsRowsCount; i++)
            {
                try
                {
                    Driver.FindElement(removeForm).Submit();
                }
                catch (NoSuchElementException)
                {
                    // do nothing if element not found
                }
            }
            return;
        }

        public string GetCartMessage()
        {
            return Driver.FindElement(cartContent).Text.Trim();
        }

        public CheckoutPage Checkout()
        {
            WaitUntilElementIsVisible(continueButton);
            Driver.FindElement(continueButton).Click();

            return this;
        }

        public void orderPurchase(string country, string state = "")
        {
            Driver.FindElement(selectCountry).SendKeys(country);
            Driver.FindElement(calculateButton).Click();
            Driver.FindElement(emailAddress).SendKeys("guest@mbox.com");
            Driver.FindElement(firstName).SendKeys("guestFirstName");
            Driver.FindElement(lastName).SendKeys("guestLastname");
            Driver.FindElement(address).SendKeys("1111, Broadway");
            Driver.FindElement(city).SendKeys("Austin");
            Driver.FindElement(billingcountry).SendKeys("USA");
            Driver.FindElement(phone).SendKeys("4257213771");            
            bool isChecked = Driver.FindElement(billingSameAsShipping).Selected;
            if (isChecked)
            {
                Driver.FindElement(purchase).Click();
            }
            else
            {
                Driver.FindElement(billingSameAsShipping).Click();               
                Driver.FindElement(purchase).Click();
            }        
            
            return;
        }
    }
}
