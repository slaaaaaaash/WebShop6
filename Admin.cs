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
            string newItemName;
            string newItemPrice;

            if (isSucceed)
            {
                switch (choice)
                {
                    case 0:
                        Start.ShowStart();
                        break;

                    case 1: //Manage Customer Info
                        break;

                    case 2: //Manage Product Info
                        Console.Clear();
                        Console.WriteLine("1. Add Product");
                        Console.WriteLine("2. Remove Product");
                        Console.WriteLine("3. Back");

                        bool addRemChoice = int.TryParse(Console.ReadLine(), out int addOrRemove);
                        if (addRemChoice)
                        {
                            switch (addOrRemove)
                            {
                                case 1: //add product
                                    Console.WriteLine("Add a new product");
                                    Console.WriteLine("Name of product:");
                                    newItemName = Console.ReadLine();
                                    Console.Clear();
                                    Console.WriteLine("Price of product:");
                                    newItemPrice = Console.ReadLine();
                                    Console.Clear();


                                    // File.WriteAllLines("../../../Products.csv");

                                    break;

                                case 2: //remove product

                                    break;

                                case 3: //back

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