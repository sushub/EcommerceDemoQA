using EcommerceDemoQA.Common;
using EcommerceDemoQA.PageValidators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EcommerceDemoQA.Tests
{
    [TestClass]
    public class EmptyCartTest:DemoQAPages
    {
        private const string CartIsEmptyMessage = "Oops, there is nothing in your cart.";
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

        #region TestMethods

        /// <summary>
        /// Verify removing all items from your cart produces an empty cart message (when multiple items are present in the cart) 
        /// </summary>
        [TestMethod]
        public void Ecommerce_RemoveMultipleItemsFromCart()
        {
            string targetPage = DemoQAPages.GetProductsPageUrl("iphones");
            ProductPage addIphoneOrder = new ProductPage(driver, targetPage);
            addIphoneOrder.AddToCartAndContinueShopping();
            targetPage = DemoQAPages.GetProductsPageUrl("ipads");
            ProductPage addIpadOrder = new ProductPage(driver, targetPage);
            CheckoutPage checkoutFinalOrder = addIpadOrder.AddToCartAndCheckout();
            checkoutFinalOrder.RemoveAllItems();

            Assert.AreEqual(CartIsEmptyMessage, checkoutFinalOrder.GetCartMessage());
        }
        #endregion

    }
}
