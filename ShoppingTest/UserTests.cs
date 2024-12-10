using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyApp.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void User_Constructor_InitializesProperties()
        {
            // Arrange
            int userId = 1;
            string userName = "user";
            string password = "password123";
            string userEmail = "user@example.com";
            int phoneNumber = 987654321;
            string street = "123 Main St";
            string city = "New York";
            string postcode = "10001";

            // Act
            User user = new User(userId, userName, password, userEmail, phoneNumber, street, city, postcode);

            // Assert
            Assert.AreEqual(userId, user.UserId);
            Assert.AreEqual(userName, user.UserName);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(userEmail, user.UserEmail);
            Assert.AreEqual(phoneNumber, user.PhoneNumber);
            Assert.AreEqual(street, user.Street);
            Assert.AreEqual(city, user.City);
            Assert.AreEqual(postcode, user.Postcode);
        }
    }
}
