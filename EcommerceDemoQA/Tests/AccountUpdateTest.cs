using EcommerceDemoQA.Common;
using EcommerceDemoQA.PageValidators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EcommerceDemoQA.Tests
{
    [TestClass] 
   public  class AccountUpdateTest:DemoQAPages
    {           
        private const string ValidUserName = "sumab";
        private const string ValidPassword = "Ganesha";

        [TestInitialize]
        public void TestInitialize()
        {
            Initialize();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            CleanUp();
        }

        /// <summary>
        /// Verify updating your account details is saved and retrieved after logging out and back in using the "My Account" link
        /// </summary>
        [TestMethod]
        public void Ecommerce_UpdateProfilePage()
        {
            LoginPage loginPage = new LoginPage(driver);
            ProfilePage profilePage = loginPage.Login(ValidUserName, ValidPassword);
            string newFirstName = Guid.NewGuid().ToString();
            string newLastName = Guid.NewGuid().ToString();
            profilePage.EditProfile(newFirstName, newLastName);
            loginPage = profilePage.Logout();
            profilePage = loginPage.Login(ValidUserName, ValidPassword);

            Assert.AreEqual(newFirstName, profilePage.GetFirstName());
            Assert.AreEqual(newLastName, profilePage.GetLastName());
        }
    }
}
