List<Product> products = new List<Product>()
{
    new Product() { Name = "Football", Price = 15.00M, Sold = false, StockDate = new DateTime(2022, 10, 20), ManufactureYear = 2010, Condition = 4.2 },
    new Product() { Name = "Hockey Stick", Price = 12.00M, Sold = false, StockDate = new DateTime(2023, 3, 5), ManufactureYear = 2018, Condition = 3.5 },
    new Product() { Name = "Frisbee", Price = 20.00M, Sold = true, StockDate = new DateTime(2023, 7, 14), ManufactureYear = 2015, Condition = 4.8 },
    new Product() { Name = "Basketball", Price = 8.00M, Sold = false, StockDate = new DateTime(2024, 1, 2), ManufactureYear = 2020, Condition = 2.9 },
    new Product() { Name = "Tennis Racket", Price = 18.00M, Sold = false, StockDate = DateTime.Now - TimeSpan.FromDays(30), ManufactureYear = 2022, Condition = 4.0 },
    new Product() { Name = "Skateboard", Price = 25.00M, Sold = true, StockDate = DateTime.Now - TimeSpan.FromDays(10), ManufactureYear = 2021, Condition = 3.1 }
};

string greeting = @"Welcome to Thrown For a Loop
Your one-stop shop for used sporting equipment";

Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. View Product Details
                        3. View Latest Products");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
    }
    else if (choice == "2")
    {
        ViewProductDetails();
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
    }
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewProductDetails()
{
    ListProducts();

    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do better!");
        }
    }

    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;

    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}, which costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old.
Condition: {chosenProduct.Condition}/5
Discounted price: ${chosenProduct.DiscountedPrice}
Shipping cost: ${chosenProduct.ShippingCost}
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}");
}

void ViewLatestProducts()
{
    List<Product> latestProducts = new List<Product>();
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    foreach (Product product in products)
    {
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }
    //Console.WriteLine("Latest products (in stock, added within 90 days):");
    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}