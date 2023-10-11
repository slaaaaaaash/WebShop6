using System.Buffers;
using System.Text;

namespace WebShop6
{
    public class Customer
    {
        public string Username;
        public string Password;

        public Customer(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public static void CustomerMenu(string username)
        {

            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine(username + "! WELCOME to: The Customer menu\n");
            Console.WriteLine(" 1. Product List");
            Console.WriteLine(" 2. Order History\n");
            Console.WriteLine(" 3. Shopping Basket\n");
            Console.WriteLine(" 0. Log out\n");
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");

            bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);
            string[] productsList = File.ReadAllLines("../../../Products.csv");

            if (isSucceed)
            {
                switch (choice)
                {
                    case 0:

                        Start.ShowStart();
                        break;

                    case 1: //Product List
                        Console.Clear();
                        Console.WriteLine("Products:");
                        Console.WriteLine("Name  " + "Price");
                        Console.WriteLine();

                        foreach (string product in productsList)
                        {
                            Console.WriteLine(product);
                        }

                        break;

                    case 2: //Order History
                        break;

                    case 3: //Shopping Basket
                        break;

                    default: //ogiltig siffra matas in
                        Console.WriteLine(" Invalid choice. Try again!");
                        Thread.Sleep(1000);
                        CustomerMenu(username);
                        break;
                }
            }
            else //ogiltig symbol matas in
            {
                Console.WriteLine("Invalid input. Try again!");
                Thread.Sleep(1000);
                CustomerMenu(username);
            }
        }


        public static void ShowCustomerList()
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            Console.Clear();
            Console.WriteLine("Customer List");
            Console.WriteLine();
            Console.WriteLine("Username\n\n");
            foreach (string customer in customers)
            {
                string[] splitCustomer = customer.Split(",");
                Console.WriteLine(splitCustomer[0]);
            }
            Console.WriteLine("\n\n");
        }

        public static string ValidateUsername()
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            bool validInput;
            string? user;
            do
            {
                validInput = false;
                Console.Clear();
                ShowCustomerList();
                Console.WriteLine("Write the username of the customer you want edit\n\n");
                user = Console.ReadLine();
                foreach (string customer in customers)
                {
                    string[] customerSplit = customer.Split(",");
                    if (customerSplit[0] == user)
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

        public static void DisplayCustomerInfo(string user)
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            Console.Clear();
            Console.WriteLine("Customer Info for : " + user);
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,-15} {1,20}\n", "Username", "Passwod"));
            foreach (string customer in customers)
            {
                string[] splitCustomer = customer.Split(",");
                if (splitCustomer[0] == user)
                {
                    Console.WriteLine(String.Format("{0,-15} {1,20:N0}", splitCustomer[0], splitCustomer[1]));
                }
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Edit username");
            Console.WriteLine("2. Edit password");
            Console.WriteLine("0. Exit");
        }

        public static void EditUsername(string username)
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            List<string> customerList = new List<string>();
            bool uniqueUser;
            string? uniqueName = string.Empty;
            do
            {
                uniqueUser = true;
                Console.Clear();
                Console.WriteLine("Enter new username");
                string? newUsername = Console.ReadLine();

                foreach (string customer in customers)
                {
                    string[] customerSplit = customer.Split(",");
                    if (customerSplit[0] == newUsername)
                    {
                        uniqueUser = false;
                    }
                }
                if (!uniqueUser)
                {
                    Console.WriteLine("Username already exists.");
                    Thread.Sleep(1000);
                }
                else
                {
                    uniqueName = newUsername;
                }
            } while (!uniqueUser);

            foreach (string customer in customers)
            {
                string[] customerSplit = customer.Split(",");
                if (customerSplit[0] == username)
                {
                    customerSplit[0] = uniqueName;
                }
                customerList.Add(customerSplit[0] + "," + customerSplit[1]);
            }
            File.WriteAllLines("../../../Customers.csv", customerList);

        }
    }
}