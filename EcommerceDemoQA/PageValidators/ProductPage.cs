/*
 * Perform all functionalities related to Product Page like:
 * 1>Adding items to cart & checking out
 * 2>Adding items to cart & continue shopping
 * 
 * */

using EcommerceDemoQA.Common;
using OpenQA.Selenium;

namespace EcommerceDemoQA.PageValidators
{
   public class ProductPage:BasePage
    {
        private readonly By addButton = By.XPath(EcommerceResources.ProductPage_addToCart);
        private readonly By goToCheckoutButton = By.XPath(EcommerceResources.ProductPage_goToCheckout);
        private readonly By continueShoppingButton = By.XPath(EcommerceResources.ProductPage_continueShopping);
        private readonly By productPrice = By.XPath(EcommerceResources.ProductPage_productPrice);

        public ProductPage(IWebDriver driver, string productPageUrl)
            : base(driver)
        {
            Driver.Url = productPageUrl;
        }

        public CheckoutPage AddToCartAndCheckout()
        {
            Driver.FindElement(addButton).Submit();
            Driver.FindElement(goToCheckoutButton).Click();
            return new CheckoutPage(Driver);
        }

        public ProductPage AddToCartAndContinueShopping()
        {
            Driver.FindElement(addButton).Submit();
            Driver.FindElement(continueShoppingButton).Click();
            return this;
        }

        public float GetProductPrice()
        {
            return DemoQAPages.GetPriceFromString(Driver.FindElement(productPrice).Text);
        }
    }
}
