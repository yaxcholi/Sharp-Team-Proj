public class ShoppingControl
{
    // List to hold users, including admins
    public static List<User> users = new List<User>();

    // Add admin sample to users
    public static void CreateSampleAdmin()
    {
        Admin admin = new Admin(1, "admin", "adminpassword", "admin@example.com", 98765999, "789 Elm St", "Chicago", "60007", DateTime.Now);
        users.Add(admin);
    }
}
