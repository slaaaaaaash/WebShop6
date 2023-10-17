namespace WebShop6;

public record Admin(string Username) : IUser
{
    public static void EditCustomer()
    {
        Customer? customer = null;
        ShowCustomerList();// shows the customer-list
        Console.WriteLine("1. Edit customer info");
        Console.WriteLine("0. Exit");
        bool returnToAdminMenu = int.TryParse(Console.ReadLine(), out int adminChoice1);
        if (returnToAdminMenu)
            switch (adminChoice1)
            {
                case 1: //Edit Customer Info
                    customer = PickCustomer(); // gets the username of the customer to be edited
                    EditCustomerMenu(customer); // Takes the customer and allows for editing.
                    break;
                case 0: //return to admin Menu
                    return;
                default: // if invalid input
                    Console.WriteLine("invalid input! try again!");
                    Thread.Sleep(1000);
                    EditCustomer();
                    break;
            }
        else // if invalid input
        {
            Console.WriteLine("invalid input! try again!");
            Thread.Sleep(1000);
            EditCustomer();
        }

        void EditCustomerMenu(Customer customer) // Sub-menu for editing a selected customers info.
        {
            DisplayCustomerInfo(customer);
            bool manageCustomerChoice = int.TryParse(Console.ReadLine(), out int adminChoice);

            if (manageCustomerChoice)
            {
                switch (adminChoice)
                {
                    case 1: //Edit username

                        customer = EditUsername(customer);
                        Thread.Sleep(1000);
                        EditCustomerMenu(customer);
                        break;

                    case 2: //Edit password
                        EditPassword(customer.Username);
                        Thread.Sleep(1000);
                        EditCustomerMenu(customer);
                        break;

                    case 0: //Exit
                        EditCustomer();
                        break;

                    default: // if invalid input
                        Console.WriteLine("invalid input! try again!");
                        Thread.Sleep(1000);
                        EditCustomer();
                        break;
                }
            }
            else // if invalid input
            {
                Console.WriteLine("invalid input! try again!");
                Thread.Sleep(1000);
                EditCustomer();
            }
        }
        static void ShowCustomerList() // Displays a list with all customers and makes sure there are no admins in the list.
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

        static Customer PickCustomer() // Checks so that the new username does not already exist and returns a newly instanciated customer
        {
            string[] users = File.ReadAllLines("users.csv");
            bool validInput;
            Customer? customer = null;
            do
            {
                validInput = false;
                Console.Clear();
                ShowCustomerList();
                string username = Utils.Promt("Write the username of the customer you want to edit\n\n");
                foreach (string line in users)
                {
                    string[] usersplit = line.Split(",");
                    if (usersplit[0].Equals(username) && usersplit[2].Equals("Customer"))
                    {
                        Cart cart = new Cart(usersplit[0]);
                        customer = new Customer(usersplit[0], cart);
                        validInput = true;
                    }
                }
                if (!validInput)
                {
                    Console.WriteLine("User does not exist, try again");
                    Thread.Sleep(1000);
                }
            } while (!validInput);
            return customer;
        }

        static void DisplayCustomerInfo(Customer user) // Displays the username and password of the selected customer
        {
            string[] users = File.ReadAllLines("users.csv");
            Console.Clear();
            Console.WriteLine("Customer Info for : " + user.Username);
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,-15} {1,20}\n", "Username", "Password"));
            foreach (string line in users)
            {
                string[] info = line.Split(",");
                if (info[0].Equals(user.Username))
                {
                    Console.WriteLine(String.Format("{0,-15} {1,20:N0}", info[0], info[1]));
                }
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Edit username");
            Console.WriteLine("2. Edit password");
            Console.WriteLine("0. Exit");
        }

        static Customer EditUsername(Customer customer) // Allows the user to enter a new username for the selected customer and prints it to the users.csv-file
        {
            string[] users = File.ReadAllLines("users.csv");
            List<string> userList = new List<string>();
            Customer? newCustomer = null;
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
                string[] userSplit = line.Split(",");
                if (userSplit[0] == customer.Username)
                {
                    File.Move($"../../../Carts/{userSplit[0]}.csv", $"../../../Carts/{uniqueName}.csv");
                    userSplit[0] = uniqueName;
                }
                userList.Add(userSplit[0] + "," + userSplit[1] + ',' + userSplit[2]);
            }
            File.WriteAllLines("users.csv", userList);
            newCustomer = new Customer(uniqueName, new Cart(uniqueName));
            return newCustomer;
        }
        static void EditPassword(string username) // Allows the user to enter a new password for the customer and prints it to te users.csv-file.
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
}
