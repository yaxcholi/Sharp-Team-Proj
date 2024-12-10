using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MyApp.Tests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        public void Category_Constructor_InitializesProperties()
        {
            // Arrange
            int categoryId = 1;
            string categoryName = "Electronics";
            string description = "Devices and gadgets";

            // Act
            Category category = new Category(categoryId, categoryName, description);

            // Assert
            Assert.AreEqual(categoryId, category.CategoryID);
            Assert.AreEqual(categoryName, category.CategoryName);
            Assert.AreEqual(description, category.Description);
        }

        [TestMethod]
        public void Category_CreateSampleCategories_ReturnsCorrectNumberOfCategories()
        {
            // Act
            List<Category> categories = Category.CreateSampleCategories();

            // Assert
            Assert.AreEqual(5, categories.Count);
        }
    }
}
