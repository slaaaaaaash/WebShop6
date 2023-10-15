using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace WebShop6;
public class LoginMenu
{
    public static void Register()
    {
        string username = string.Empty;
        bool usernameFree;
        do
        {
            usernameFree = true;
            while (username.Length is < 4 or > 12)
            {
                username = Utils.Promt("Enter a desired username containing at 4-12 characters and no whitespaces: ");
                if (username.Contains(' '))
                {
                    username = string.Empty;
                    Console.WriteLine("No whitespaces please");
                }
            }

            string[] users = File.ReadAllLines("users.csv");
            foreach (string line in users)
            {
                string[] info = line.Split(',');
                if (info[0] == username)
                {
                    usernameFree = false;
                }
            }
            if (!usernameFree)
            {
                Console.WriteLine("Username already taken, try again");
                username = string.Empty;
            }
        } while (!usernameFree);

        string password = string.Empty;
        while (password.Length is < 8 or > 64)
        {
            password = Utils.Promt("Enter a password with at least 8 charactes: ");
            Console.Clear();
            Console.Write("Please re-enter your password: ");
            if (!password.Equals(Console.ReadLine()))
            {
                password = string.Empty;
                Console.WriteLine("Passwords did not match");
            }
        }

        File.AppendAllText("users.csv", $"{username},{password},{Role.Customer}\n");
        File.Create($"Carts/{username}");
    }
    public static IUser Login()
    {
        Admin admin = new Admin("Admin");
        return admin;
    }

}