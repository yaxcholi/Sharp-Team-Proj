[TestClass]
public class AdminTests
{
    [TestMethod]
    public void Admin_Constructor_InitializesProperties()
    {
        // Arrange
        int userId = 1;
        string userName = "admin";
        string password = "adminpassword"; // Assuming password is a required field
        string userEmail = "admin@example.com";
        int phoneNumber = 98765999;
        string street = "789 Elm St";
        string city = "Chicago";
        string postcode = "60007";
        DateTime lastLogin = DateTime.Now;

        // Act
        Admin admin = new Admin(userId, userName, password, userEmail, phoneNumber, street, city, postcode, lastLogin);

        // Assert
        Assert.AreEqual(userId, admin.UserId);
        Assert.AreEqual(userName, admin.UserName);
        Assert.AreEqual(userEmail, admin.UserEmail);
        Assert.AreEqual(phoneNumber, admin.PhoneNumber);
        Assert.AreEqual(street, admin.Street);
        Assert.AreEqual(city, admin.City);
        Assert.AreEqual(postcode, admin.Postcode);
        Assert.AreEqual(lastLogin.Date, admin.LastLogin.Date); // Comparing only the date part
    }

    [TestMethod]
    public void Admin_CreateSampleAdmin_AddsAdminToUsersList()
    {
        // Act
        Admin.CreateSampleAdmin();

        // Assert
        Assert.AreEqual(1, ShoppingControl.users.Count, "Admin list should contain one user.");
        Assert.IsInstanceOfType(ShoppingControl.users[0], typeof(Admin), "The added user should be of type Admin.");
        Assert.AreEqual("admin", ShoppingControl.users[0].UserName, "The username of the added admin should be 'admin'.");
    }
}
