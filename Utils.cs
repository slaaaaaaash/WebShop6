namespace WebShop6;

public class Utils
{
    public static string Promt(string message)
    {
        Console.Write(message);
        return Console.ReadLine() ?? string.Empty;
    }
}