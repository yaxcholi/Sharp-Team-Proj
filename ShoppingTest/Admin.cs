public class Admin : User
{
    // Property for last login (specific to Admin)
    public DateTime LastLogin { get; set; }

    // Constructor for Admin class
    public Admin(int userId, string userName, string password, string userEmail,
                 int phoneNumber, string street, string city, string postcode, DateTime lastLogin)
        : base(userId, userName, password, userEmail, phoneNumber, street, city, postcode)  // Calling base class User constructor
    {
        this.LastLogin = lastLogin;
    }

    // Method to create a sample Admin and add it to the users list
    public static void CreateSampleAdmin()
    {
        Admin admin = new Admin(1, "admin", "adminpassword", "admin@example.com",
                                98765999, "789 Elm St", "Chicago", "60007", DateTime.Now);
        ShoppingControl.users.Add(admin);
    }
}
