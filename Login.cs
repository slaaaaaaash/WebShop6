using System.Runtime.CompilerServices;

namespace WebShop6;
public class Login
{
    public static string AddUsername()
    {
        string UserName;
        bool validUser;
        do
        {
            bool validInput;
            do
            {
                validInput = true;
                Console.WriteLine("Please enter username and password to log in:");
                Console.Write("username: ");
                UserName = Console.ReadLine();
                if (UserName.Length <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please make sure you've actually entered a username.");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    validInput = false;
                }
            } while (!validInput);
            if (!ValidateUsername(UserName))
            {
                Console.WriteLine();
                Console.WriteLine("Username does not exist, press any key to try again");
                Console.ReadKey();
                Console.Clear();
                AddUsername();
            }
            else
                validUser = true;
            return UserName;
        } while (!validUser);
    }
   
    public static string AddPassword(string username)
    {
        string UserName = username;
        string Password;
        bool validPass;
        do
        {
            bool validInput;
            do
            {
                validInput = true;
                Console.Clear();
                Console.WriteLine("Please enter username and password to log in:");
                Console.Write("username: ");
                Console.WriteLine(UserName);
                Console.Write("Password: ");
                Password = Login.MaskedPass();
                Console.WriteLine();
                if (Password.Length <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please make sure you've actually entered a password.");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    validInput = false;
                }
            } while (!validInput);
            if (!ValidatePassword(UserName, Password))
            {
                Console.WriteLine();
                Console.WriteLine("You've entered the incorrect password, press any key to try again.");
                Console.ReadKey();
                Console.Clear();
                AddPassword(UserName);
            }
            else
                validPass = true;
            return Password;
        } while (!validPass);
    }
    public static bool ValidateUsername(string username)
    {
        string user = username;
        string[] customers = File.ReadAllLines("../../../Customers.csv");
        string[] admins = File.ReadAllLines("../../../Admins.csv");
        bool validUsername = false;
        foreach (string customer in customers)
        {
            string[] splitCustomer = customer.Split(",");
            if (splitCustomer[0] == user)
            {
                validUsername = true;
            }
        }

        foreach (string admin in admins)
        {
            string[] splitAdmin = admin.Split(",");
            if (splitAdmin[0] == user)
            {
                validUsername = true;
            }
        }

        if (validUsername)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ValidatePassword(string username, string password)
    {
        string user = username;
        string pass = password;
        string[] customers = File.ReadAllLines("../../../Customers.csv");
        string[] admins = File.ReadAllLines("../../../Admins.csv");
        bool validPass = false;
        foreach (string customer in customers)
        {
            string[] splitCustomer = customer.Split(",");
            if (splitCustomer[0] == user && splitCustomer[1] == pass)
            {
                validPass = true;
            }
        }

        foreach (string admin in admins)
        {
            string[] splitAdmin = admin.Split(",");
            if (splitAdmin[0] == user && splitAdmin[1] == pass)
            {
                validPass = true;
            }
        }

        if (validPass == true)
        {
            return true;
        }
        else
        {
            return false;
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
    
    /* working function for finding out if user is an Admin or a Customer we might want this to happen here in at the login or somewhere else in the program.
     
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

    */
}