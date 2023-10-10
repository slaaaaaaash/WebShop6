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
            Console.WriteLine();
            Console.WriteLine("Choice 1");
            Console.WriteLine("Choice 2");
            Console.WriteLine("Choice 3");
            Console.WriteLine("Choice 4");
        }
    }
}