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
                        Customer.ShowCustomerList();
                        Console.WriteLine("Write the username of the customer you want edit\n\n");
                        string pickedUser = Customer.DisplayCustomerInfo();
                        Console.WriteLine("\n\n");
                        Console.WriteLine("1. Edit username");
                        Console.WriteLine("2. Edit password");
                        Console.WriteLine("3. Exit");

                        bool manageCustomerChoice = int.TryParse(Console.ReadLine(), out int adminChoice);

                        if (manageCustomerChoice)
                        {
                            switch (adminChoice)
                            {
                                case 1: //Edit username
                                    Customer.EditUsername(pickedUser);
                                    break;

                                case 2: //Edit password
                                    break;

                                case 3: //Exit
                                    break;
                            }
                        }






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

    }
}