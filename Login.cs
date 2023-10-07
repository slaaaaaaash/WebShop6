using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace WebShop6;
public class Login
{
    public static bool LogInUser()
    {
        string? UserName;
        string? UserPassword;
        bool validInput;
        bool validPassword;

        do
        {
            validPassword = true;
            do
            {
                validInput = true;
                Console.Clear();
                Console.WriteLine("Welcome to the time-travelling Feline!");
                Console.WriteLine();
                Console.WriteLine("Please enter username and password to log in:");
                Console.Write("Username: ");
                UserName = Console.ReadLine();
                Console.Write("Password: ");
                UserPassword = Login.MaskedPass();
                Console.WriteLine();
                if (UserPassword.Length <= 0 || UserName.Length <= 0)
                {
                    Console.WriteLine("Please make sure you've actually entered both a username and a password.");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    validInput = false;
                }
            } while (!validInput);

            if (ValidateUser(UserName, UserPassword))
            {
                validPassword = true;
            }
            else
            {
                Console.WriteLine("Invalid username or password, press any key to try again");
                Console.ReadKey();
                Console.Clear();
                validPassword = false;
            }
        } while (!validPassword);
        return true;
    }
    private static bool ValidateUser(string username, string password)
    {
        string[] listCustomers= File.ReadAllLines("../../../Customers.csv");
        bool validCustomerLogin = false;
        foreach (string customer in listCustomers)
        {
            string[] customerInfo = customer.Split(",");
            string customerUsername = customerInfo[0];
            string customerPassword = customerInfo[1];
            if(customerUsername == username && customerPassword == password)
            {
                validCustomerLogin = true;
            }
            else
            {
               validCustomerLogin = false;
            }
        }

        string[] listAdmins = File.ReadAllLines("../../../Admins.csv");
        bool validAdminLogin = false;
        foreach (string admin in listAdmins)
        {
            string[] adminInfo = admin.Split(",");
            string adminUsername = adminInfo[0];
            string adminPassword = adminInfo[1];
            if(adminUsername == username && adminPassword == password)
            {
                validAdminLogin = true;
            }
            else
            {
               validAdminLogin = false;
            }
        }

        if (validCustomerLogin)
        {
            return true;
        }
        else if (validAdminLogin)
        {
            return true;
        }
        else
            return false;
    }

    private static string MaskedPass()
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
        }while (key.Key != ConsoleKey.Enter) ;
        return pass;
    }
}