using System.Runtime.InteropServices;

namespace WebShop6;

public class ManageCustomer
{
    public static void Menu() // The menu for managing a customer
    {
        ShowCustomerList();
        Console.WriteLine("1. Edit customer info");
        Console.WriteLine("0. Exit");
        bool returnToAdminMenu = int.TryParse(Console.ReadLine(), out int adminChoice1);
        if (returnToAdminMenu)
            switch (adminChoice1)
            {
                case 1: //Edit Customer Info
                    string pickedUser = ValidateUsername();
                    EditCustomerMenu(pickedUser);
                    break;
                case 0: //return to admin Menu
                    return;
                    break;
                default: // if invalid input
                    Console.WriteLine("invalid input! try again!");
                    Thread.Sleep(1000);
                    Menu();
                    break;
            }
        else // if invalid input
        {
            Console.WriteLine("invalid input! try again!");
            Thread.Sleep(1000);
            Menu();
        }
    }
    public static void EditCustomerMenu(string customer) // Sub-menu for editing a selected customers info.
    {
        DisplayCustomerInfo(customer);
        bool manageCustomerChoice = int.TryParse(Console.ReadLine(), out int adminChoice);

        if (manageCustomerChoice)
        {
            switch (adminChoice)
            {
                case 1: //Edit username
                    string newUsername = EditUsername(customer);
                    Thread.Sleep(1000);
                    EditCustomerMenu(newUsername);
                    break;

                case 2: //Edit password
                    EditPassword(customer);
                    Thread.Sleep(1000);
                    EditCustomerMenu(customer);
                    break;

                case 0: //Exit
                    Menu();
                    break;

                default: // if invalid input
                    Console.WriteLine("invalid input! try again!");
                    Thread.Sleep(1000);
                    Menu();
                    break;
            }
        }
        else // if invalid input
        {
            Console.WriteLine("invalid input! try again!");
            Thread.Sleep(1000);
            Menu();
        }
    }
    public static void ShowCustomerList() // Displays a list with all customers and makes sure there are no admins in the list.
    {
        string[] users = File.ReadAllLines("users.csv");
        Console.Clear();
        Console.WriteLine("Customer List\n\n");
        Console.WriteLine("Username\n");
        foreach (string line in users)
        {
            string[] info = line.Split(",");
            if (info[2].Equals("Customer"))
                Console.WriteLine(info[0]);
        }
        Console.WriteLine("\n\n");
    }

    public static string ValidateUsername() // Checks so that the new username does not already exist
    {
        string[] users = File.ReadAllLines("users.csv");
        bool validInput;
        string? user;
        do
        {
            validInput = false;
            Console.Clear();
            ShowCustomerList();
            user = Utils.Promt("Write the username of the customer you want to edit\n\n");
            foreach (string line in users)
            {
                string[] usersplit = line.Split(",");
                if (usersplit[0].Equals(user) && usersplit[2].Equals("Customer"))
                {
                    validInput = true;
                }
            }
            if (!validInput)
            {
                Console.WriteLine("User does not exist, try again");
                Thread.Sleep(1000);
            }
        } while (!validInput);
        return user;
    }

    public static void DisplayCustomerInfo(string user) // Displays the username and password of the selected customer
    {
        string[] users = File.ReadAllLines("users.csv");
        Console.Clear();
        Console.WriteLine("Customer Info for : " + user);
        Console.WriteLine();
        Console.WriteLine(String.Format("{0,-15} {1,20}\n", "Username", "Password"));
        foreach (string line in users)
        {
            string[] info = line.Split(",");
            if (info[0].Equals(user))
            {
                Console.WriteLine(String.Format("{0,-15} {1,20:N0}", info[0], info[1]));
            }
        }
        Console.WriteLine("\n\n");
        Console.WriteLine("1. Edit username");
        Console.WriteLine("2. Edit password");
        Console.WriteLine("0. Exit");
    }

    public static string EditUsername(string username) // Allows the user to enter a new username for the selected customer and prints it to the users.csv-file.
    {
        string[] users = File.ReadAllLines("users.csv");
        List<string> userList = new List<string>();
        bool uniqueUser;
        string? uniqueName = string.Empty;
        string? newUsername = string.Empty;
        do
        {
            uniqueUser = true;
            Console.Clear();
            newUsername = Utils.Promt("Enter new username: ");

            foreach (string line in users)
            {
                string[] usersplit = line.Split(",");
                if (usersplit[0] == newUsername || newUsername.Length is < 4 or > 12)
                {
                    uniqueUser = false;
                }
            }
            if (!uniqueUser)
            {
                Console.WriteLine("Username already exists or is invalid, try again.");
                Thread.Sleep(1000);

            }
            else
            {
                uniqueName = newUsername;
            }
        } while (!uniqueUser);

        foreach (string line in users)
        {
            string[] usersplit = line.Split(",");
            if (usersplit[0] == username)
            {
                usersplit[0] = uniqueName;
            }
            userList.Add(usersplit[0] + "," + usersplit[1] + ',' + usersplit[2]);
        }
        File.WriteAllLines("users.csv", userList);
        return newUsername;
    }
    public static void EditPassword(string username) // Allows the user to enter a new password for the customer and prints it to te users.csv-file.
    {
        string[] users = File.ReadAllLines("users.csv");
        List<string> userList = new List<string>();
        Console.Clear();
        string? newPassword = Utils.Promt("Enter new password: ");

        foreach (string line in users)
        {
            string[] usersplit = line.Split(",");
            if (usersplit[0] == username)
            {
                usersplit[1] = newPassword;
            }
            userList.Add(usersplit[0] + "," + usersplit[1] + ',' + usersplit[2]);
        }
        File.WriteAllLines("users.csv", userList);
    }

}