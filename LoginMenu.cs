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
                Console.Clear();
                username = Utils.Promt("Enter a desired username containing at 4-12 characters and no whitespaces: ");
                if (username.Contains(' '))
                {
                    username = string.Empty;
                    Console.WriteLine("No whitespaces please");
                    Thread.Sleep(750);
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
                Console.WriteLine("\nUsername already taken, try again");
                username = string.Empty;
            }
        } while (!usernameFree);

        string password = string.Empty;
        while (password.Length is < 8 or > 64)
        {
            Console.Clear();
            Console.Write("Enter a password with at least 8 charactes: ");
            password = MaskedPass() ?? string.Empty;
            Console.Clear();
            Console.Write("Please re-enter your password: ");
            if (!password.Equals(MaskedPass() ?? string.Empty))
            {
                password = string.Empty;
                Console.WriteLine("Passwords did not match");
                Thread.Sleep(750);
            }
        }

        File.AppendAllText("users.csv", $"{username},{password},{Role.Customer}\n");
        File.Create($"Carts/{username}").Close();
    }
    public static IUser Login()
    {
        string[] users = File.ReadAllLines("users.csv");
        IUser user = null;
        while (true)
        {
            Console.Clear();
            string input = Utils.Promt("Enter your username: ");
            foreach (string line in users)
            {
                string[] info = line.Split(',');
                if (info[0].Equals(input))
                {
                    Console.Write("Enter your password: ");
                    input = MaskedPass() ?? string.Empty;

                    switch (info[2])
                    {
                        case "Admin":
                            user = new Admin(info[0]);
                            break;
                        case "Customer":
                            user = new Customer(info[0], new List<Product>());
                            break;
                        default:
                            throw new Exception();
                    }
                    return user;
                }
            }
            Console.WriteLine("User does not exist");
        }
    }

    public static string MaskedPass()
    {
        string pass = string.Empty;
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                pass += key.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass = pass.Substring(0, (pass.Length - 1));
                    Console.Write("\b \b");
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        } while (key.Key != ConsoleKey.Enter);
        return pass;
    }
}