public class Customer : User
{
    // Additional properties specific to Customer
    public string Role { get; set; }
    public string Status { get; set; }
    public ShoppingBasket Basket { get; set; }

    // Constructor
    public Customer(int userId, string userName, string userEmail, int phoneNumber, string street, string city, string postcode, string role, string status)
        : base(userId, userName, "defaultPassword", userEmail, phoneNumber, street, city, postcode)
    {
        this.Role = role;
        this.Status = status;
        this.Basket = new ShoppingBasket();
    }

    // Method to create a sample customer and add to users list
    public static void CreateSampleCustomer()
    {
        // Creating a sample customer
        Customer customer = new Customer(1, "customer1", "jane.doe@example.com", 1234567890, "123 Maple St", "Chicago", "60007", "Standard", "Active");

        // Adding the customer to the users list in ShoppingControl
        ShoppingControl.users.Add(customer);
    }
}
