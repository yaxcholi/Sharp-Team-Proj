public class Admin : User
{
    private DateTime lastLogin;

    public Admin(
        int userId,
        string userName,
        string userEmail,
        int phoneNumber,
        string street,
        string city,
        string postcode,
        DateTime lastLogin
    ) : base(userId, userName, "password", userEmail, phoneNumber, street, city, postcode)
    {
        this.lastLogin = lastLogin;
    }

    // This method creates sample admin data
    public static void CreateSampleAdmin()
    {
        Console.WriteLine("Creating sample admins...");

        // Creating a sample admin
        Admin admin1 = new Admin( 1,  "admin",  "admin@example.com",  98765999, "789 Elm St", "Chicago", "60007", DateTime.Now);

        // Adding the sample admin to the shared users list in ShoppingControl
        ShoppingControl.users.Add(admin1);

        Console.WriteLine("Sample admins created.");
        Console.WriteLine($"Created admin: {admin1.UserName}");
    }

    public DateTime LastLogin { get; set; }
}


