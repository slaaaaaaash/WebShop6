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
                        break;

                    case 2: //Manage Product Info
                        Console.Clear();
                        Console.WriteLine("1. Add Product");
                        Console.WriteLine("2. Remove Product");
                        Console.WriteLine("3. Edit Product");
                        Console.WriteLine("4. Back");

                        bool addRemChoice = int.TryParse(Console.ReadLine(), out int addOrRemove);

                        string newItemName, newItemPrice, editItem;

                        if (addRemChoice)
                        {
                            switch (addOrRemove)
                            {
                                case 1: //add product
                                    Console.Clear();

                                    Console.WriteLine("Add a new product");
                                    Console.WriteLine("Name of product:");
                                    newItemName = Console.ReadLine();

                                    Console.Clear();

                                    Console.WriteLine("Price of product:");
                                    newItemPrice = Console.ReadLine();

                                    string[] products = File.ReadAllLines("../../../Products.csv");

                                    string[] nameAndPrice = { newItemName + "," + newItemPrice };
                                    File.AppendAllLines("../../../Products.csv", nameAndPrice);

                                    Console.Clear();

                                    break;

                                case 2: //remove product
                                    string[] productsList = File.ReadAllLines("../../../Products.csv");

                                    Console.Clear();

                                    foreach (string product in productsList)
                                    {
                                        Console.WriteLine(product);
                                    }

                                    Console.WriteLine("Choose a product to remove");

                                    bool remChoice = int.TryParse(Console.ReadLine(), out int Remove);
                                    Remove = Remove - 1;

                                    List<string> list = File.ReadAllLines("../../../Products.csv").ToList();
                                    string itemRem = list[Remove];
                                    list.RemoveAt(Remove);
                                    File.WriteAllLines("../../../Products.csv", list.ToArray());

                                    break;

                                case 3: //Edit product WIP

                                    string[] productsListEdit = File.ReadAllLines("../../../Products.csv");

                                    Console.Clear();

                                    foreach (string product in productsListEdit)
                                    {
                                        Console.WriteLine(product);
                                    }

                                    Console.WriteLine("Choose a product to edit");
                                    bool editChoice = int.TryParse(Console.ReadLine(), out int Edit);
                                    Edit = Edit - 1;

                                    List<string> editList = File.ReadAllLines("../../../Products.csv").ToList();
                                    string itemEdit = editList[Edit];

                                    Console.WriteLine("The items new name and price:");
                                    editItem = Console.ReadLine();

                                    editList[Edit] = editItem;
                                    File.WriteAllLines("../../../Products.csv", editList.ToArray());

                                    break;


                                case 4: //back

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