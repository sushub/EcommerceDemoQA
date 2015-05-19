using EcommerceDemoQA.Common;
using EcommerceDemoQA.PageValidators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EcommerceDemoQA.Tests
{
    [TestClass]
    public class SubmitOrderTest:DemoQAPages
    {
     private const string PurchaseMessage = "Transaction Results";
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
    /// Order for an Apple iPhone4s 16GB SIM-Free – Black and verify the Total Price: given is correct 
    /// </summary>
      [TestMethod]        
        public void Ecommerce_VerifyTotalPriceforOrder()
        {
            string targetPage = DemoQAPages.GetProductsPageUrl("iphones");
            ProductPage iphoneOrder = new ProductPage(driver, targetPage);
            float productPrice = iphoneOrder.GetProductPrice();
            CheckoutPage checkoutPage = iphoneOrder.AddToCartAndCheckout();
            CheckoutPage checkoutInfoPage = checkoutPage.Checkout();
            checkoutInfoPage.orderPurchase("USA");
            TransactionResultsPage orderPurchase = new TransactionResultsPage(driver);
            orderPurchase = orderPurchase.CalculateTotalPrice();
            Assert.AreEqual(PurchaseMessage, orderPurchase.GetTranasactionHeaderMessage());
            Assert.AreEqual((productPrice + orderPurchase.TotalShippingPrice), orderPurchase.TotalPrice);
       }
    }
}


