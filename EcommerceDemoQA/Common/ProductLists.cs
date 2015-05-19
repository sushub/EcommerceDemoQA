/*
 * Common Utility functions used for building sample product list
 *  
 * */

using EcommerceDemoQA.Common.Enums;
using System.Collections.Generic;


namespace EcommerceDemoQA.Common
{
  public static class ProductLists
    {
      public static Dictionary<ProductTypes, string> product = new Dictionary<ProductTypes, string>();
      
      
      public static void addProducts (ProductTypes productType, string item)
      {

          if (!product.ContainsKey(productType))
              product.Add(productType, item);
      }

      public static string getProductLists(ProductTypes productType)
      {
        if(product.ContainsKey(productType))
        {
            string item = product[productType];
            return item;
        }

        return null;
      }

      //Adding some existing Products to list
      public static Dictionary<ProductTypes, string> prePopulate(Dictionary<ProductTypes, string> product)
      {
          ProductLists.addProducts(ProductTypes.accessories, "magic-mouse");          
          ProductLists.addProducts(ProductTypes.imacs, "magic-mouse");
          ProductLists.addProducts(ProductTypes.ipods, "apple-ipod-touch-large");
          ProductLists.addProducts(ProductTypes.ipads, "apple-ipad-6-32gb-white-3d");
          ProductLists.addProducts(ProductTypes.ipads, "apple-ipad-2-16gb-wi-fi-9-7in-black");
          ProductLists.addProducts(ProductTypes.iphones, "apple-iphone-4s-16gb-sim-free-black");
          ProductLists.addProducts(ProductTypes.iphones, "apple-iphone-4s-32gb-sim-free-white");
          ProductLists.addProducts(ProductTypes.macbooks, "apple-13-inch-macbook-pro");
          return product;        
      }   
        
  
   }
}
