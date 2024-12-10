public class Customer : User
{
    private string role;
    private string status;

    public ShoppingBasket Basket { get; set; }  // Basket property to store the shopping basket

    public Customer(
        int userId,
        string userName,
        string userEmail,
        int phoneNumber,
        string street,
        string city,
        string postcode,
        string role,
        string status
    ) : base(userId, userName, "1234", userEmail, phoneNumber, street, city, postcode)
    {
        this.Role = !string.IsNullOrWhiteSpace(role) ? role : throw new ArgumentException("Role cannot be null or empty.");
        this.Status = !string.IsNullOrWhiteSpace(status) ? status : throw new ArgumentException("Status cannot be null or empty.");
        this.Basket = new ShoppingBasket();
    }

    public string Role
    {
        get => role;
        set => role = value;
    }

    public string Status
    {
        get => status;
        set => status = value;
    }

    public static void CreateSampleCustomer()
    {
        Console.WriteLine("Creating sample customer...");

        Customer customer = new Customer(
            1,
            "customer1",
            "jane.doe@example.com",
            1234567890,
            "123 Maple St",
            "Chicago",
            "60007",
            "Standard",
            "Active"
        );

        ShoppingControl.users.Add(customer);  // Add to the global users list
        Console.WriteLine($"Created customer: {customer.UserName}");
    }
}
