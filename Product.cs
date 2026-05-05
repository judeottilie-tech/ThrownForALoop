public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public DateTime StockDate { get; set; }
    public int ManufactureYear { get; set; }
    public double Condition { get; set; }

    public double DiscountedPrice
    {
        get
        {
            return (double)Price / 2;
        }
    }

    public int ShippingCost
    {
        get
        {
            return (Price > 10) ? 0 : 5;
        }
    }
}