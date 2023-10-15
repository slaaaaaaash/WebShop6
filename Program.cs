using WebShop6;

IUser? user = null;
bool logOut;
do
{
    logOut = false;
    do
    {
        Console.Clear();
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");
        Console.WriteLine(" WELCOME to: The Time-travelling Feline Shop\n");
        Console.WriteLine(" 1. Login ");
        Console.WriteLine(" 2. Register\n");
        Console.WriteLine(" 0. Exit\n");
        Console.WriteLine($"******************************************************************");
        Console.WriteLine($"****************************************************************** \n");

        bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);

        if (isSucceed)
        {
            switch (choice)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("*******************************************************************\n");
                    Console.WriteLine(" Welcome back!\n");
                    Console.WriteLine("*******************************************************************");
                    Console.WriteLine("*******************************************************************\n");
                    Thread.Sleep(3000);
                    Console.Clear();
                    Console.WriteLine("Program has exited.");
                    Environment.Exit(1);
                    break;

                case 1: //login 
                    user = LoginMenu.Login();
                    break;

                case 2: // register new customer 
                    LoginMenu.Register();
                    break;

                default: //invalid input
                    Console.WriteLine(" Invalid choice. Try again!");
                    Thread.Sleep(1000);
                    break;
            }
        }
        else //invalid input
        {
            Console.WriteLine("Invalid input. Try again!");
            Thread.Sleep(1000);
        }
    } while (user == null);

    if (user is Customer c)
    {
        bool customerReturn;
        do
        {
            customerReturn = true;
            Console.Clear();
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");
            Console.WriteLine(c.Username.ToUpper() + "! WELCOME to: The Time-travelling Feline Shop\n");
            Console.WriteLine(" 1. Product List ");
            Console.WriteLine(" 2. Order History\n");
            Console.WriteLine(" 3. View Shopping Cart\n");
            Console.WriteLine(" 0. Log out\n");
            Console.WriteLine($"******************************************************************");
            Console.WriteLine($"****************************************************************** \n");

            bool isSucceed = int.TryParse(Console.ReadLine(), out int choice);

            if (isSucceed)
            {
                switch (choice)
                {
                    case 0:
                        logOut = true;
                        break;

                    case 1: //Product List 
                        Console.Clear();
                        string[] products = File.ReadAllLines("products.csv");
                        List<Product> listProducts = new List<Product>();
                        foreach (string line in products)
                        {
                            string[] info = line.Split(',');
                            Product product = new Product(info);
                            listProducts.Add(product);
                        }
                        for (int i = 0; i < listProducts.Count; i++)
                        {
                            Product line = listProducts[i];
                            Console.WriteLine(line.Name + " [" + (i + 1) + "]");
                            Console.WriteLine("Price: " + line.Price + "kr");
                            Console.WriteLine("Description: " + line.Description + "\n");
                        }
                        Console.ReadKey();
                        customerReturn = false;
                        break;

                    case 2: // Order History 
                        customerReturn = false;
                        break;

                    case 3: // Shopping Cart
                        customerReturn = false;
                        break;

                    default: //invalid input
                        Console.WriteLine(" Invalid choice. Try again!");
                        customerReturn = false;
                        Thread.Sleep(1000);
                        break;
                }
            }
            else //invalid input
            {
                Console.WriteLine("Invalid input. Try again!");
                customerReturn = false;
                Thread.Sleep(1000);
            }
        } while (!customerReturn);



    }
    else if (user is Admin a)
    {
        Console.Clear();
        Console.WriteLine("\nCongrats you've succesfully logged in as an admin");
        Console.WriteLine(a.Username);
    }

} while (logOut);
