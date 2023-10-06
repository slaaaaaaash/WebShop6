namespace WebShop6;
public class Login
{
    public static void LogInUser()
    {
        Console.WriteLine("Please enter username and password:");
        Console.Write("Username: ");
        string? UserName = Console.ReadLine();
        Console.Write("Password: ");
        string? UserPassword = Console.ReadLine();
    }
    private void ImportUsers(string username, string password)
    {
        string[] listUsers = File.ReadAllLines("../../../Users.csv");
    }
}