/*
 * Perform all Common functionalities shared across all tests like:
 * 1>Dynamically constructing the url for all pages
 * 2>Prepopulating sample list of products
 *  
 * */

using EcommerceDemoQA.Common.Enums;
using EcommerceDemoQA.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
namespace EcommerceDemoQA.Common
{
    public class DemoQAPages
    {
        protected IWebDriver driver;
        public void Initialize()
        {
            driver = new ChromeDriver();           
        }

        public void CleanUp()
        {
            driver.Dispose();
        }

        protected const string HomePageURL = "http://store.demoqa.com";
        Dictionary<ProductTypes, string> prod = ProductLists.prePopulate(ProductLists.product);

        /// <summary>
        /// Gets Ecommerce Homepage URL
        /// </summary>
        public static string HomePageUrl
        {
            get
            {
                return HomePageURL;
            }
        }

        /// <summary>
        /// Gets Ecommerce Product Page URL
        /// </summary>
        public static string GetProductsPageUrl(string productType)
        {             
            ProductTypes productSubcategory = ParseproductType(productType);
            string productItem = ProductLists.getProductLists(productSubcategory);
            string url = string.Format("{0}/{1}/{2}/{3}", DemoQAPages.HomePageUrl, Categories.ProductCategory, productSubcategory, productItem);                 
            
            return url;
        }

        /// <summary>
        /// Gets non Product Page URL
        /// </summary>
        public static string GetPageUrl(string pageType)
        {
            string url = string.Empty;
            if (PageTypes.LoginPage.ToString().Equals(pageType))
            {                
                url = string.Format("{0}/{1}/", DemoQAPages.HomePageUrl, Categories.LoginPage);
            }

            else if (PageTypes.CheckoutPage.ToString().Equals(pageType))
            {
                url = string.Format("{0}/{1}/", DemoQAPages.HomePageUrl, Categories.CheckoutPage);
            }

            else if (PageTypes.ProfilePage.ToString().Equals(pageType))
            {
                url = string.Format("{0}/{1}/", DemoQAPages.HomePageUrl, Categories.ProfilePage);
            }

            return url;
        }
        
        /// <summary>
        /// Parse ProductTypes strings from specified ProductType.
        /// </summary>
        /// <param name="type">ProductTypes representation of ProductTypes enumeration value.</param>
        /// <returns>string value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If ProductTypes does not parse into a valid string value.</exception>
        public static ProductTypes ParseproductType(string type)
        {
            if (ProductTypes.accessories.ToString("g").Equals(type))
            {               
                return ProductTypes.accessories;
            }

            if (ProductTypes.imacs.ToString("g").Equals(type))
            {               
                return ProductTypes.imacs;
            }

            if (ProductTypes.ipads.ToString("g").Equals(type))
            {                
                return ProductTypes.ipads;
            }

            if (ProductTypes.iphones.ToString("g").Equals(type))
            {                
                return ProductTypes.iphones;
            }

            if (ProductTypes.ipods.ToString("g").Equals(type))
            {
                return ProductTypes.ipods;
            }

            if (ProductTypes.macbooks.ToString("g").Equals(type))
            {               
                return ProductTypes.macbooks;
            }

            throw new ArgumentOutOfRangeException("ProductTypes", string.Format("Could not parse  value"));
        }

        /// <summary>
        /// Ecommerce Page Categories
        /// </summary>
        public static class Categories
        {
            /// <summary>
            /// Products url segment
            /// </summary>
            public static readonly string ProductCategory = "products-page//product-category";

            /// <summary>
            /// Login url segment
            /// </summary>
            public static readonly string LoginPage = "tools-qa";

            /// <summary>
            /// Profile Page url segment
            /// </summary>
            public static readonly string ProfilePage = "wp-admin//profile.php";

            /// <summary>
            /// Checkout Page url segment
            /// </summary>
            public static readonly string CheckoutPage = "products-page//checkout";          
        }
 
        /// <summary>
        /// Ecommerce Subpage Categories
        /// </summary>
        public static class SubCategories
        {            
            /// <summary>
            /// Product SubCategory url segment for accessories.
            /// </summary>
            public static readonly string productsAccessories = "accessories";  

            /// <summary>
            /// Product SubCategory url segment for imacs.
            /// </summary>
            public static readonly string productsImacs = "imacs";
           
            /// <summary>
            /// Product SubCategory url segment for ipads.
            /// </summary>
            public static readonly string productsIpads = "ipads";    

            /// <summary>
            /// Product SubCategory url segment for iPhones.
            /// </summary>
            public static readonly string productsIPhones = "iphones"; 
 
            /// <summary>
            /// Product SubCategory url segment for ipods.
            /// </summary>
            public static readonly string productsIpods = "ipods";

            /// <summary>
            /// Product SubCategory url segment for macbooks.
            /// </summary>
            public static readonly string productsMacbooks = "macbooks";
        }

        /// <summary>
        /// Gets Price by removing the currency value
        /// </summary>  
        public static float GetPriceFromString(string price)
        {
            return Convert.ToSingle(price.Replace("$", string.Empty));      
        }
    }
}