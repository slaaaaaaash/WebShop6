using System.Runtime.CompilerServices;

namespace WebShop6;
public class Login
{
    /*
        public static string LogInUser()
        {

        }
    */

    public static Enum ValidateUsername(string username)
    {
        string user = username;
        string[] customers = File.ReadAllLines("../../../Customers.csv");
        string[] admins = File.ReadAllLines("../../../Admins.csv");
        string usertype = string.Empty;
        foreach (string customer in customers)
        {
            string[] splitCustomer = customer.Split(",");
            if (splitCustomer[0] == user)
            {
                usertype = "Customer";
            }
        }

        foreach (string admin in admins)
        {
            string[] splitAdmin = admin.Split(",");
            if (splitAdmin[0] == user)
            {
                usertype = "Admin";
            }
        }

        if (usertype == "Customer")
        {
            return ValidationResults.Customer;
        }
        else if (usertype == "Admin")
        {
            return ValidationResults.Admin;
        }
        else
        {
            return ValidationResults.Username;
        }
    }

    
    /*
    public static bool ValidatePassword(string username, string password)
    {
        switch (ImportUserLogin("../../../" + ValidateUsername(username) + ".csv")[username] == password)
        {
            case true:
                return true;
            case false:
                return false;
        }
    }

    */
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