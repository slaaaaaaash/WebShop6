using System.Runtime.CompilerServices;

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
                UserPassword = Console.ReadLine();
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
}