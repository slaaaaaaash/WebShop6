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
            Console.WriteLine(username + "! Welcome to the Admin Menu!");
            Console.WriteLine();
            Console.WriteLine("Choice 1");
            Console.WriteLine("Choice 2");
            Console.WriteLine("Choice 3");
            Console.WriteLine("Choice 4");
            
        }
    }
}