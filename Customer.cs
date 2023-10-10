namespace WebShop6
{
    public class Customer
    {
        public string CustomerUsername;
        public string CustomerPassword;

        public Customer(string username, string password)
        {
            CustomerUsername = username;
            CustomerPassword = password;
        }
        public static void CustomerMenu(string username)
        {
            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine(username + "! WELCOME to: The Admin menu\n");
            Console.WriteLine(" 1. Product List");
            Console.WriteLine(" 2. Order History\n");
            Console.WriteLine(" 3. Shopping Basket\n");
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

                    case 1: //Product List
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

    }
}