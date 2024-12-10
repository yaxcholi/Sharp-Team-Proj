using System.Linq;

public class ShoppingControl
{
    public static List<User> users = new List<User>(); // Shared list for all users

    private List<Product> products = Product.GetSampleProducts();
    private List<Category> categories = Category.CreateSampleCategories();
    private List<Product> basket;

    public ShoppingControl()
    {
        // Ensure users list is populated with sample data
        Admin.CreateSampleAdmin();  // Adds sample admins to the users list
        Customer.CreateSampleCustomer();  // Adds sample customers to the users list
    }

    public void Run()
    {
        while (true) // Loop to handle re-login
        {
            // Authenticate user before proceeding to menus
            User? authenticatedUser = Authenticate();

            if (authenticatedUser != null)
            {
                // After successful login, show the main menu
                DisplayMainMenu(authenticatedUser);
            }
            else
            {
                // If authentication fails
                Console.WriteLine("Authentication failed. Exiting...");
                return; // Exit program if user fails login
            }
        }
    }

    public void DisplayMainMenu(User authenticatedUser)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Online Shop Main Menu");

            if (authenticatedUser is Admin)
            {
                Console.WriteLine("Welcome to the Admin Menu");
                if (!DisplayAdminMenu()) break; // Exit loop on logout
            }
            else if (authenticatedUser is Customer customer) 
            {
                Console.WriteLine("Welcome to the Customer Menu");
                if (!DisplayCustomerMenu(customer)) break; // Exit loop on logout
            }
        }
    }

    public bool DisplayAdminMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. Manage Products");
            Console.WriteLine("2. Manage Categories");
            Console.WriteLine("3. Manage Users");
            Console.WriteLine("4. Logout");
            Console.Write("Please select an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ManageProducts();
                    break;
                case "2":
                    ManageCategories();
                    break;
                case "3":
                    ManageUsers();
                    break;
                case "4":
                    Logout();
                    return false; // Indicate logout
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }


    // Customer Menu 
    public bool DisplayCustomerMenu(Customer customer)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Customer Menu:");
            Console.WriteLine("1. Browse Products");
            Console.WriteLine("2. Browse Categories");
            Console.WriteLine("3. View Shopping Basket");
            Console.WriteLine("4. Logout");
            Console.Write("Please select an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewProductsAndAddToBasket(customer.Basket);
                    break;
                case "2":
                    ViewCategories();
                    break;
                case "3":
                    customer.Basket.ViewBasket(); // Display basket contents
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey(); // Pause to allow user to see the output
                    break;
                case "4":
                    Console.WriteLine("Logging out...");
                    return false;  
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    // Method to display products and allow adding to the basket
    public void ViewProductsAndAddToBasket(ShoppingBasket basket)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Available Products:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].ProductName} - ${products[i].Price} (Quantity: {products[i].Quantity})");
            }
            Console.WriteLine("0. Return to Menu");
            Console.Write("Enter the number of the product to add to your basket: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0) break; // Return to menu
                if (choice > 0 && choice <= products.Count)
                {
                    Product selectedProduct = products[choice - 1];
                    if (selectedProduct.Quantity > 0)  // Check if the product is available
                    {
                        basket.AddToBasket(selectedProduct);  // Add the product to the basket
                        products[choice - 1].Quantity--;  // Decrement the product quantity
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, {selectedProduct.ProductName} is out of stock.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }


public void Logout()
    {
        Console.WriteLine("Logging out...");
        Console.WriteLine("Press any key to return to the login screen...");
        Console.ReadKey();
    }

    // Method to authenticate a user
    public User? Authenticate()
        {
        Console.WriteLine("User List:");
        
        foreach (var user in users)
        {
            Console.WriteLine($"Username: {user.UserName}, Password: {user.Password}");
        }

        Console.WriteLine("Please login");

        // Ask for username and password
        Console.Write("Enter Username: ");
        string? username = Console.ReadLine();

        Console.Write("Enter Password: ");
        string? password = Console.ReadLine();

        // Check user credentials (search through userList)
        foreach (var user in users)
        {
            if (user.UserName == username && user.Password == password)
            {
                Console.WriteLine($"Welcome, {user.UserName}!");
                return user; // Return the authenticated user
            }
        }

        // If no matching user, inform the user and return null
        Console.WriteLine("Invalid credentials. Please try again.");
        return null;
    }

    // Method to display the main menu based on user type (Admin or Customer)
 

    // Manage Categories Logic
    public void ManageCategories()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Manage Categories:");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Remove Category");
            Console.WriteLine("3. View Categories");
            Console.WriteLine("4. Update Categories");
            Console.WriteLine("5. Exit");

            Console.Write("Please select an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddCategory();
                    break;

                case "2":
                    RemoveCategory();
                    break;

                case "3":
                    ViewCategories();
                    break;

                case "4":
                    UpdateCategories();
                    break;

                case "5":
                    return; // Exit
                    break;


                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    // Methods for Viewing, Adding, and Removing Categories

    private void UpdateCategories()
    {
        Console.Clear();
        Console.WriteLine("Update an existing category:");

        // Display existing categories
        if (categories.Count == 0)
        {
            Console.WriteLine("No categories available to update.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Available Categories:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].CategoryName} (ID: {categories[i].CategoryID})");
        }

        // Ask the user to select a category by ID
        Console.Write("Enter the number of the category you want to update: ");
        if (!int.TryParse(Console.ReadLine(), out int categoryChoice) || categoryChoice < 1 || categoryChoice > categories.Count)
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        // Get the selected category
        Category selectedCategory = categories[categoryChoice - 1];

        // Display and let the user update category details
        Console.WriteLine($"Updating Category: {selectedCategory.CategoryName}");

        Console.Write("Enter new Category Name (leave empty to keep current): ");
        string? newCategoryName = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newCategoryName))
        {
            if (categories.Any(c => c.CategoryName.Equals(newCategoryName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("A category with this name already exists.");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                return;
            }
            selectedCategory.CategoryName = newCategoryName;  // Update category name
        }

        Console.Write("Enter new Description (leave empty to keep current): ");
        string? newDescription = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newDescription))
        {
            selectedCategory.Description = newDescription;  // Update description
        }

        // Confirm update
        Console.WriteLine($"Category '{selectedCategory.CategoryName}' updated successfully.");
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }
    private void AddCategory()
    {
        Console.Clear();
        Console.WriteLine("Add a New Category:");

        Console.Write("Enter Category ID: ");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter the Category Name: ");
        string? categoryName = Console.ReadLine()?.Trim();

        Console.Write("Enter a Description: ");
        string? description = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(description))
        {
            Console.WriteLine("Category name and description cannot be empty.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        if (categories.Any(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("A category with this name already exists.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        categories.Add(new Category(categoryId, categoryName, description));
        Console.WriteLine($"Category '{categoryName}' added successfully.");
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    private void RemoveCategory()
    {
        Console.Clear();
        Console.WriteLine("Remove a Category:");

        if (categories.Count == 0)
        {
            Console.WriteLine("No categories available to remove.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Available categories:");
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {categories[i].CategoryName} (ID: {categories[i].CategoryID})");
        }

        Console.Write("Enter the number of the category to remove: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= categories.Count)
        {
            var removedCategory = categories[choice - 1];
            categories.RemoveAt(choice - 1);
            Console.WriteLine($"Category '{removedCategory.CategoryName}' removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    private void ViewCategories()
    {
        Console.Clear();
        Console.WriteLine("View Categories:");

        if (categories.Count == 0)
        {
            Console.WriteLine("No categories available.");
        }
        else
        {
            foreach (var category in categories)
            {
                category.DisplayCategoryDetails();
                Console.WriteLine(); // Blank line for better readability
            }
        }

        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    // Manage Users Logic
    public void ManageUsers()
    {
        Console.Clear();
        Console.WriteLine("Manage Users:");
        Console.WriteLine("1. View Users");
        Console.WriteLine("2. Add User");
        Console.WriteLine("3. Remove User");
        Console.WriteLine("4. Update User");
        Console.WriteLine("5. Exit");

        Console.Write("Please select an option: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ViewUsers(); // View all users
                break;

            case "2":
                AddUser(); // Add a new user
                break;

            case "3":
                RemoveUser(); // Remove a user
                break;

            case "4":
                UpdateUser();
                break;

            case "5":
                return;
                break;

            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    // Methods for Viewing, Adding, and Removing Users

    private void UpdateUser()
    {
        Console.Clear();
        Console.WriteLine("Update an existing user:");

        // Display existing users
        if (users.Count == 0)
        {
            Console.WriteLine("No users available to update.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Available Users:");
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {users[i].UserName} (ID: {users[i].UserId})");
        }

        // Ask the user to select a user by ID
        Console.Write("Enter the number of the user you want to update: ");
        if (!int.TryParse(Console.ReadLine(), out int userChoice) || userChoice < 1 || userChoice > users.Count)
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        // Get the selected user
        User selectedUser = users[userChoice - 1];

        // Display and let the user update user details
        Console.WriteLine($"Updating User: {selectedUser.UserName}");

        Console.Write("Enter new Username (leave empty to keep current): ");
        string? newUsername = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newUsername))
        {
            if (users.Any(u => u.UserName.Equals(newUsername, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("A user with this username already exists.");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                return;
            }
            selectedUser.UserName = newUsername;  // Update username
        }

        Console.Write("Enter new Email (leave empty to keep current): ");
        string? newEmail = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newEmail))
        {
            selectedUser.UserEmail = newEmail;  // Update email
        }

        Console.Write("Enter new Phone Number (leave empty to keep current): ");
        string? newPhoneNumberInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newPhoneNumberInput) && int.TryParse(newPhoneNumberInput, out int newPhoneNumber))
        {
            selectedUser.PhoneNumber = newPhoneNumber;  // Update phone number
        }

        Console.Write("Enter new Street (leave empty to keep current): ");
        string? newStreet = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newStreet))
        {
            selectedUser.Street = newStreet;  // Update street
        }

        Console.Write("Enter new City (leave empty to keep current): ");
        string? newCity = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newCity))
        {
            selectedUser.City = newCity;  // Update city
        }

        Console.Write("Enter new Postcode (leave empty to keep current): ");
        string? newPostcode = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newPostcode))
        {
            selectedUser.Postcode = newPostcode;  // Update postcode
        }

        // Confirm update
        Console.WriteLine($"User '{selectedUser.UserName}' updated successfully.");
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    private void ViewUsers()
    {
        Console.Clear();
        Console.WriteLine("List of Users:");

        if (users.Count == 0)
        {
            Console.WriteLine("No users available.");
            return;
        }

        foreach (var user in users)
        {
            Console.WriteLine($"Username: {user.UserName}, Role: {user.GetType().Name}");
        }

        Console.WriteLine("Press any key to go back to the menu...");
        Console.ReadKey();
    }

    private void AddUser()
    {
        Console.Clear();
        Console.WriteLine("Add a New User:");

        // Ask for user type (Admin or Customer)
        Console.Write("Enter User Type (Admin/Customer): ");
        string? userType = Console.ReadLine()?.Trim();

        // Ask for user details
        Console.Write("Enter User ID: ");
        int userId = Convert.ToInt32(Console.ReadLine()?.Trim());

        Console.Write("Enter Username: ");
        string? username = Console.ReadLine()?.Trim();

        Console.Write("Enter Password: ");
        string? password = Console.ReadLine()?.Trim();

        Console.Write("Enter Email: ");
        string? email = Console.ReadLine()?.Trim();

        Console.Write("Enter Phone Number: ");
        int phoneNumber = Convert.ToInt32(Console.ReadLine()?.Trim());

        Console.Write("Enter Street: ");
        string? street = Console.ReadLine()?.Trim();

        Console.Write("Enter City: ");
        string? city = Console.ReadLine()?.Trim();

        Console.Write("Enter Postcode: ");
        string? postcode = Console.ReadLine()?.Trim();

        // Validate the input
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(userType) ||
            string.IsNullOrEmpty(email) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(postcode))
        {
            Console.WriteLine("Invalid input. All fields are required.");
            return;
        }

        // Check if the user already exists
        foreach (var user in users)
        {
            if (user.UserName == username)
            {
                Console.WriteLine("A user with this username already exists.");
                return;
            }
        }

        // Create the user based on the user type
        User newUser = userType.ToLower() switch
        {
            "admin" => new Admin(userId, username, email, phoneNumber, street, city, postcode, DateTime.Now),
            "customer" => new Customer(userId, username, email, phoneNumber, street, city, postcode, "Customer", "Active"),
            _ => null
        };

        if (newUser != null)
        {
            users.Add(newUser);
            Console.WriteLine($"{userType} user added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid user type. Please choose either Admin or Customer.");
        }

        Console.WriteLine("Press any key to go back to the menu...");
        Console.ReadKey();
    }

    private void RemoveUser()
    {
        Console.Clear();
        Console.WriteLine("Remove a User:");

        // Ask for the username to remove
        Console.Write("Enter the Username to remove: ");
        Console.WriteLine();
        foreach (var user in users)
        {
            Console.WriteLine($"Username: {user.UserName}, Role: {user.GetType().Name}");
        }
        string? usernameToRemove = Console.ReadLine()?.Trim();

        // Find the user by username
        User userToRemove = users.Find(u => u.UserName == usernameToRemove);

        if (userToRemove != null)
        {
            users.Remove(userToRemove);
            Console.WriteLine($"User {usernameToRemove} removed successfully.");
            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}, Role: {user.GetType().Name}");
            }
        }

        else
        {
            Console.WriteLine("User not found.");
        }

        Console.WriteLine("Press any key to go back to the menu...");
        Console.ReadKey();
    }


    // Methods for Viewing, Adding, and Removing Products

    // Manage Products Logic
    public void ManageProducts()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Manage Products:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Remove Product");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Exit");

            Console.Write("Please select an option: ");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;

                case "2":
                    RemoveProduct();
                    break;

                case "3":
                    ViewProducts();
                    break;

                case "4":
                    UpdateProduct(); // Exit
                    break;

                case "5":
                    return;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    private void UpdateProduct()
    {
        Console.Clear();
        Console.WriteLine("Update an existing product:");

        // Display existing products
        if (products.Count == 0)
        {
            Console.WriteLine("No products available to update.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Available Products:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].ProductName} (ID: {products[i].ProductID})");
        }

        // Ask the user to select a product by ID
        Console.Write("Enter the number of the product you want to update: ");
        if (!int.TryParse(Console.ReadLine(), out int productChoice) || productChoice < 1 || productChoice > products.Count)
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        // Get the selected product
        Product selectedProduct = products[productChoice - 1];

        // Display and let the user update product details
        Console.WriteLine($"Updating Product: {selectedProduct.ProductName}");

        Console.Write("Enter new Product Name (leave empty to keep current): ");
        string? newProductName = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newProductName))
        {
            if (products.Any(p => p.ProductName.Equals(newProductName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("A product with this name already exists.");
                Console.WriteLine("Press any key to go back...");
                Console.ReadKey();
                return;
            }
            selectedProduct.ProductName = newProductName;  // Update product name
        }

        Console.Write("Enter new Product Description (leave empty to keep current): ");
        string? newProductDescription = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newProductDescription))
        {
            selectedProduct.ProductDescription = newProductDescription;  // Update description
        }

        Console.Write("Enter new Price (leave empty to keep current): ");
        string? newPriceInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newPriceInput) && double.TryParse(newPriceInput, out double newPrice) && newPrice >= 0)
        {
            selectedProduct.Price = newPrice;  // Update price
        }

        Console.Write("Enter new Quantity (leave empty to keep current): ");
        string? newQuantityInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newQuantityInput) && int.TryParse(newQuantityInput, out int newQuantity) && newQuantity >= 0)
        {
            selectedProduct.Quantity = newQuantity;  // Update quantity
        }

        Console.Write("Enter new Category ID (leave empty to keep current): ");
        string? newCategoryIdInput = Console.ReadLine()?.Trim();
        if (!string.IsNullOrEmpty(newCategoryIdInput) && int.TryParse(newCategoryIdInput, out int newCategoryId))
        {
            selectedProduct.CategoryID = newCategoryId;  // Update category ID
        }

        // Confirm update
        Console.WriteLine($"Product '{selectedProduct.ProductName}' updated successfully.");
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    private void AddProduct()
    {
        Console.Clear();
        Console.WriteLine("Add a New Product:");

        Console.Write("Enter Product ID: ");
        if (!int.TryParse(Console.ReadLine(), out int productId))
        {
            Console.WriteLine("Invalid ID. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Product Name: ");
        string? productName = Console.ReadLine()?.Trim();

        Console.Write("Enter Product Description: ");
        string? productDescription = Console.ReadLine()?.Trim();

        Console.Write("Enter Product Price: ");
        if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
        {
            Console.WriteLine("Invalid price. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Quantity: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid quantity. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter Category ID: ");
        if (!int.TryParse(Console.ReadLine(), out int categoryId))
        {
            Console.WriteLine("Invalid category ID. Please enter a valid number.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        if (products.Any(p => p.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("A product with this name already exists.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        products.Add(new Product(productId, productName, productDescription, price, quantity, categoryId));
        Console.WriteLine($"Product '{productName}' added successfully.");
        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    private void RemoveProduct()
    {
        Console.Clear();
        Console.WriteLine("Remove a Product:");

        if (products.Count == 0)
        {
            Console.WriteLine("No products available to remove.");
            Console.WriteLine("Press any key to go back...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Available products:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].ProductName} (ID: {products[i].ProductID}, Price: {products[i].Price:C})");
        }

        Console.Write("Enter the number of the product to remove: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= products.Count)
        {
            var removedProduct = products[choice - 1];
            products.RemoveAt(choice - 1);
            Console.WriteLine($"Product '{removedProduct.ProductName}' removed successfully.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }

    private void ViewProducts()
    {
        Console.Clear();
        Console.WriteLine("Product List:");

        if (products.Count == 0)
        {
            Console.WriteLine("No products available.");
        }
        else
        {
            foreach (var product in products)
            {
                product.DisplayProductDetails();
                Console.WriteLine(); // Blank line for better readability
            }
        }

        Console.WriteLine("Press any key to go back...");
        Console.ReadKey();
    }


}
