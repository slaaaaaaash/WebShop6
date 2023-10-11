namespace WebShop6
{
    public class Admin
    {

        public string AdminUsername;
        public string AdminPassword;

        public Admin(string username, string password)
        {
            AdminUsername = username;
            AdminPassword = password;
        }

        public static void AdminMenu(string username)
        {
            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine(username + "! WELCOME to: The Admin menu\n");
            Console.WriteLine(" 1. Manage Customer Info ");
            Console.WriteLine(" 2. Manage Products\n");
            Console.WriteLine(" 3. Manage Orders\n");
            Console.WriteLine(" 0. Log out\n");
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");

            bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);

            if (isSucceed)
            {
                switch (choice)
                {
                    case 0:
                        Start.ShowStart();
                        break;

                    case 1: //Manage Customer Info
                        ManageCustomer(username);
                        break;


                    case 3: //Manage Orders
                        break;

                    default: //ogiltig siffra matas in
                        Console.WriteLine(" Invalid choice. Try again!");
                        Thread.Sleep(1000);
                        AdminMenu(username);
                        break;
                }
            }
            else //ogiltig symbol matas in
            {
                Console.WriteLine("Invalid input. Try again!");
                Thread.Sleep(1000);
                AdminMenu(username);
            }

        }

        public static void ManageCustomer(string username)
        {
            Customer.ShowCustomerList();
            Console.WriteLine("1. Edit customer info");
            Console.WriteLine("0. Exit");
            bool returnToAdminMenu = int.TryParse(Console.ReadLine(), out int adminChoice1);
            if (returnToAdminMenu)
                switch (adminChoice1)
                {
                    case 1: //Edit Customer Info
                        string pickedUser = Customer.ValidateUsername();
                        EditCustomerInfo(username, pickedUser);
                        break;
                    case 0: //return to admin Menu
                        AdminMenu(username);
                        break;
                    default: // if invalid input
                        Console.WriteLine("Invalid input! Try again!");
                        Thread.Sleep(1000);
                        ManageCustomer(username);
                        break;
                }
            else // if invalid input
            {
                Console.WriteLine("Invalid input! Try again!");
                Thread.Sleep(1000);
                ManageCustomer(username);
            }


        }
        public static void EditCustomerInfo(string username, string customer)
        {
            Customer.DisplayCustomerInfo(customer);
            bool manageCustomerChoice = int.TryParse(Console.ReadLine(), out int adminChoice);

            if (manageCustomerChoice)
            {
                switch (adminChoice)
                {
                    case 1: //Edit username
                        Customer.EditUsername(customer);
                        Thread.Sleep(1000);
                        EditCustomerInfo(username, customer);
                        break;

                    case 2: //Edit password
                        break;

                    case 0: //Exit
                        ManageCustomer(username);
                        break;
                }
            }

        }
    }
}