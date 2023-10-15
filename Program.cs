using WebShop6;

IUser? user = null;

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
    Console.Clear();
    Console.WriteLine("\nCongrats you've succesfully logged in as a customer");
    Console.WriteLine(c.Username);
    Console.WriteLine(c.Cart);
}
else if (user is Admin a)
{
    Console.Clear();
    Console.WriteLine("\nCongrats you've succesfully logged in as an admin");
    Console.WriteLine(a.Username);
}
