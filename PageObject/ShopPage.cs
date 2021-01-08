using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using PlanItAssessment.Enumerations;
using System.Linq;

namespace PlanItAssessment.PageObject
{
    public interface IShopPage
    {
        string GetPrice(Products item);
    }

    internal class ShopPage : PageObjectBase, IShopPage
    {
        //Method
        public string GetPrice(Products item)
        {
            var products = GetProducts();
            var rightItem = products.FirstOrDefault(x => x.ProductName.Replace(" ", String.Empty).ToLower() == item.ToString().ToLower());
            return rightItem.ProductPrice.ToString();
        }

        private IReadOnlyList<Product> GetProducts()
        {
            var products = new List<Product>();
            var itemList = GetItemListElements();
            foreach (var item in itemList)
            {
                var itemName = item.FindElement(By.ClassName("product-title"));
                var productPrice = item.FindElement(By.ClassName("product-price"));
                products.Add(new Product()
                {
                    ProductName = itemName.Text,
                    ProductPrice = productPrice.Text
                });
            }
            return products;
        }

        //Elements
        private IReadOnlyList<IWebElement> GetItemListElements()
        {
            //var mainContainer = Driver.FindElement(By.ClassName("products"));
            var list = Driver.FindElements(By.CssSelector(".product.ng-scope"));

            return list;
        }
    }
}
