using System;
using System.Collections.Generic;

public class Category
{
    // Properties
    public int CategoryID { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }

    // Constructor
    public Category(int categoryId, string categoryName, string description)
    {
        CategoryID = categoryId;
        CategoryName = categoryName;
        Description = description;
    }

    // Method to display category details
    public void DisplayCategoryDetails()
    {
        Console.WriteLine($"Category ID: {CategoryID}");
        Console.WriteLine($"Category Name: {CategoryName}");
        Console.WriteLine($"Description: {Description}");
    }

    // Method to create sample categories
    public static List<Category> CreateSampleCategories()
    {
        List<Category> categories = new List<Category>
        {
            new Category(1, "Electronics", "Devices and gadgets"),
            new Category(2, "Household", "Household items and appliances"),
            new Category(3, "Clothing", "Clothing for men, women, and children"),
            new Category(4, "Books", "Fiction, non-fiction, educational, and more"),
            new Category(5, "Toys & Games", "Toys for kids, board games, and puzzles")
        };

        return categories;
    }
}
