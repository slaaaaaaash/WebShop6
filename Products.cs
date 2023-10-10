namespace WebShop6
{
    public class Products
    {

        public string ProductName;
        public int ProductPrice;
        public int ProductDate;

        public Products(string name, int price, int date)
        {
            ProductName = name;
            ProductPrice = price;
            ProductDate = date;
        }
    }
}