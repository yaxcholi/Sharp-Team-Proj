public class ShoppingBasket
{
    private List<Product> basket;  // List to store selected products
    public double TotalPrice { get; private set; }

    public ShoppingBasket()
    {
        basket = new List<Product>();
        TotalPrice = 0;
    }

    // Add a product to the basket
    public void AddToBasket(Product product)
    {
        basket.Add(product);  // Add the product to the basket
        TotalPrice += product.Price;  // Update the total price
        Console.WriteLine($"{product.ProductName} added to your basket.");
    }

    // View items in the basket
    public void ViewBasket()
    {
        if (basket.Count == 0)
        {
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("|        SHOPPING BASKET        |");
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("|        The basket is empty.   |");
            Console.WriteLine("+-------------------------------+");
            return;
        }

        Console.Clear();
        Console.WriteLine("+---------------------------------------------------------------+");
        Console.WriteLine("|                         SHOPPING BASKET                      |");
        Console.WriteLine("+---------------------------------------------------------------+");
        Console.WriteLine("+------------+--------------------+----------+");
        Console.WriteLine("| Product ID | Product Name       | Price    |");
        Console.WriteLine("+------------+--------------------+----------+");

        double grandTotal = 0;

        foreach (var item in basket)
        {
            string trimmedProductName = item.ProductName.Length > 18 ? item.ProductName.Substring(0, 15) + "..." : item.ProductName;

            Console.WriteLine($"| {item.ProductID,-10} | {trimmedProductName,-18} | ${item.Price,-8:F2} |");
            grandTotal += item.Price;
        }

        Console.WriteLine("+------------+--------------------+----------+");
        Console.WriteLine($"| {' ',-32} Grand Total: ${grandTotal,-8:F2} |");
        Console.WriteLine("+---------------------------------------------------------------+");
    }
}