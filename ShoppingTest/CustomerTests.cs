using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Xml.Linq;

namespace MyApp.Tests
{
    [TestClass]
    public class CustomerTests
    {
        [TestInitialize]
        public void Setup()
        {
            // Clear the users list before each test
            ShoppingControl.users.Clear();
        }

        [TestMethod]
        public void Customer_Constructor_InitializesProperties()
        {
            // Arrange
            int userId = 1;
            string userName = "customer1";
            string userEmail = "jane.doe@example.com";
            int phoneNumber = 1234567890;
            string street = "123 Maple St";
            string city = "Chicago";
            string postcode = "60007";
            string role = "Standard";
            string status = "Active";

            // Act
            Customer customer = new Customer(userId, userName, userEmail, phoneNumber, street, city, postcode, role, status);

            // Assert
            Assert.AreEqual(userId, customer.UserId);
            Assert.AreEqual(userName, customer.UserName);
            Assert.AreEqual(userEmail, customer.UserEmail);
            Assert.AreEqual(phoneNumber, customer.PhoneNumber);
            Assert.AreEqual(street, customer.Street);
            Assert.AreEqual(city, customer.City);
            Assert.AreEqual(postcode, customer.Postcode);
            Assert.AreEqual(role, customer.Role);
            Assert.AreEqual(status, customer.Status);
            Assert.IsNotNull(customer.Basket); // Check that the basket is initialized
        }

        [TestMethod]
        public void Customer_CreateSampleCustomer_AddsCustomerToUsersList()
        {
            // Act
            Customer.CreateSampleCustomer();

            // Assert
            Assert.AreEqual(1, ShoppingControl.users.Count, "User  list should contain one user.");
            Assert.IsInstanceOfType(ShoppingControl.users[0], typeof(Customer), "The added user should be of type Customer.");
            Assert.AreEqual("customer1", ShoppingControl.users[0].UserName, "The username of the added customer should be 'customer1'.");
        }

        [TestMethod]
        public void Customer_SetAndGetProperties_WorkCorrectly()
        {
            // Arrange
            Customer customer = new Customer(1, "customer1", "jane.doe@example.com", 1234567890, "123 Maple St", "Chicago", "60007", "Standard", "Active");

            // Act
            customer.Role = "Premium";
            customer.Status = "Inactive";

            // Assert
            Assert.AreEqual("Premium", customer.Role, "Role should be updated to 'Premium'.");
            Assert.AreEqual("Inactive", customer.Status, "Status should be updated to 'Inactive'.");
        }
    }
}