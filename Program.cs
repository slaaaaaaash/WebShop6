using WebShop6;

public class Program
{
    static void Main(string[] args)
    {
        //Start.ShowStart();
        FileReader.Printer();
        foreach (var item in FileReader.products)
        {
            Console.WriteLine($"{item.ProductName} , {item.ProductPrice};-");

        }
        ShoppingCart.EditCart();
        Console.ReadKey();
    }
}