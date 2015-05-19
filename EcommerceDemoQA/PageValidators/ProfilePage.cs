/*
 * Perform all functionalities related to profile Page like:
 * 1>Editing Profile
 * 2>log out
 * 
 * */

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EcommerceDemoQA.PageValidators
{
   public class ProfilePage:BasePage
    {
        private readonly By firstName = By.XPath(EcommerceResources.ProfilePage_firstName);
        private readonly By lastName = By.XPath(EcommerceResources.ProfilePage_lastName);
        private readonly By updateProfileButton = By.XPath(EcommerceResources.ProfilePage_updateProfile);
        private readonly By accountSubMenu = By.XPath(EcommerceResources.ProfilePage_accountSubmenu);
        private readonly By logOut = By.XPath(EcommerceResources.ProfilePage_accountLogout);

        public ProfilePage(IWebDriver driver)
            : base(driver)
        {

        }

        public ProfilePage EditProfile(string newFirstName, string newLastName)
        {
            Driver.FindElement(firstName).Clear();
            Driver.FindElement(firstName).SendKeys(newFirstName);
            Driver.FindElement(lastName).Clear();
            Driver.FindElement(lastName).SendKeys(newLastName);
            Driver.FindElement(updateProfileButton).Click();
            return this;
        }

        public LoginPage Logout()
        {
            Actions a = new Actions(Driver);
            a.MoveToElement(Driver.FindElement(accountSubMenu)).Build().Perform();
            WaitUntilElementIsVisible(logOut);
            Driver.FindElement(logOut).Click();
            return new LoginPage(Driver, true);
        }

        public string GetFirstName()
        {
            return GetElementAttribute(firstName, "value");
        }

        public string GetLastName()
        {
            return GetElementAttribute(lastName, "value");
        }
    }
}
