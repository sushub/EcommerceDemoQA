/*
 * Perform common functionalities used across different pages like getting attribute of a web element, implicit wait time.
 * 
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace EcommerceDemoQA.PageValidators
{
   public  class BasePage
    {
         protected readonly IWebDriver Driver;

         protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
        }

        protected void WaitUntilElementIsVisible(By element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        protected string GetElementAttribute(By element, string attributeName)
        {
            return Driver.FindElement(element).GetAttribute(attributeName);
        }
    }
}
