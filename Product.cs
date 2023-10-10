namespace WebShop6
{
    public class Product
    {

        public string ProductName;
        public int ProductPrice;
        public int ProductDate;

        public Product(string name, int price, int date)
        {
            ProductName = name;
            ProductPrice = price;
            ProductDate = date;
        }
    }
}