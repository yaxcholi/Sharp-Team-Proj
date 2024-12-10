using System;
using System.Collections.Generic;

public class Product
{
    // Properties
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryID { get; set; }

    // Constructor
    public Product(int productId, string productName, string productDescription, double price, int quantity, int categoryId)
    {
        ProductID = productId;
        ProductName = productName;
        ProductDescription = productDescription;
        Price = price;
        Quantity = quantity;
        CategoryID = categoryId;
    }

    // Method to display product details
    public void DisplayProductDetails()
    {
        Console.WriteLine($"Product ID: {ProductID}");
        Console.WriteLine($"Product Name: {ProductName}");
        Console.WriteLine($"Description: {ProductDescription}");
        Console.WriteLine($"Price: {Price:C}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Category ID: {CategoryID}");
    }

    // Sample method to get sample products
    public static List<Product> GetSampleProducts()
    {
        return new List<Product>
        {
            new Product(1, "LED TV 65 inch", "Samsung LED TV", 459.99, 5, 1),
            new Product(2, "Vacuum Cleaner", "Dyson V11 Vacuum Cleaner", 599.99, 10, 2),
            new Product(3, "Running Shoes", "Nike Air Zoom Pegasus", 120.00, 20, 3),
            new Product(4, "Software programming", "C# for beginners", 12.99, 25, 4),
            new Product(5, "Blender", "NutriBullet Pro", 89.99, 15, 2),
            new Product(6, "Smartphone", "iPhone 13", 999.99, 8, 5)
        };
    }
}
