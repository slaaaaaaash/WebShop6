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
            Console.WriteLine(username + "! Welcome to the Customer Menu!");
            Console.WriteLine("Please enter the number corresponding to your choice");
            Console.WriteLine();
            Console.WriteLine("1. List of Products");
            Console.WriteLine("Choice 2");
            Console.WriteLine("Choice 3");
            Console.WriteLine("Choice 4");

            bool customerChoice = int.TryParse(Console.ReadLine(), out int choice);

            if (customerChoice)
            {
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("test0");
                        break;
                    case 1:
                        Console.WriteLine("test1");
                        break;
                    case 2:
                        Console.WriteLine("test2");
                        break;
                    case 3:
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}