/*
 * Perform all functionalities related to Login Page like:
 * Logging onto the store website 
 * 
 * */

using EcommerceDemoQA.Common;
using OpenQA.Selenium;

namespace EcommerceDemoQA.PageValidators
{
    public class LoginPage:BasePage
    {
        private readonly By userName = By.XPath(EcommerceResources.LoginPage_UserName);
        private readonly By userPassword = By.XPath(EcommerceResources.LoginPage_password);
        private readonly By submitButton = By.XPath(EcommerceResources.LoginPage_submit);

        public LoginPage(IWebDriver driver, bool loggedOut = false)
            : base(driver)
        {

            if (loggedOut)
            {               
                Driver.Url = DemoQAPages.GetPageUrl("LoginPage") + "?loggedout=true";
            }
            else
            {
                Driver.Url = DemoQAPages.GetPageUrl("LoginPage");
            }
        }

        public ProfilePage Login(string user, string password)
        {
            Driver.FindElement(userName).Clear();
            Driver.FindElement(userName).SendKeys(user);
            Driver.FindElement(userPassword).Clear();
            Driver.FindElement(userPassword).SendKeys(password);
            Driver.FindElement(submitButton).Click();

            return new ProfilePage(Driver);
        }

    }
}
