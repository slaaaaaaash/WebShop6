namespace WebShop6;

public class Cart
{
    public List<Product> Products;

    public Cart(string username)
    {
        string[] data = File.ReadAllLines($"../../../Carts/{username}.csv");
        List<Product> cart = new List<Product>();
        foreach (string item in data)
        {
            string[] info = item.Split(',');
            Product product = new Product(info);
            cart.Add(product);
        }
        Products = cart;
    }
}