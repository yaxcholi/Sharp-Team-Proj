using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MyApp.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void Product_Constructor_InitializesProperties()
        {
            // Arrange
            int productId = 1;
            string productName = "LED TV 65 inch";
            string productDescription = "Samsung LED TV";
            double price = 459.99;
            int quantity = 5;
            int categoryId = 1;

            // Act
            Product product = new Product(productId, productName, productDescription, price, quantity, categoryId);

            // Assert
            Assert.AreEqual(productId, product.ProductID);
            Assert.AreEqual(productName, product.ProductName);
            Assert.AreEqual(productDescription, product.ProductDescription);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
            Assert.AreEqual(categoryId, product.CategoryID);
        }

        [TestMethod]
        public void Product_GetSampleProducts_ReturnsCorrectNumberOfProducts()
        {
            // Act
            List<Product> products = Product.GetSampleProducts();

            // Assert
            Assert.AreEqual(6, products.Count);
        }
    }
}
