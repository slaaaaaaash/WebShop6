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
                        AdminMenu.Menu(username);
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
                        string newUsername = Customer.EditUsername(customer);
                        Thread.Sleep(1000);
                        EditCustomerInfo(username, newUsername);
                        break;

                    case 2: //Edit password
                        Customer.EditPassword(customer);
                        Thread.Sleep(1000);
                        EditCustomerInfo(username, customer);
                        break;

                    case 0: //Exit
                        ManageCustomer(username);
                        break;
                }
            }

        }
    }
}