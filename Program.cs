using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using WebShop6;
string newname;
string input;


Console.WriteLine("Welcome to the Time-travelling Feline");

Console.Write("Please enter new user name: ");
CheckExisting(Console.ReadLine());

Console.WriteLine("Please enter password: ");
SecurePass(Console.ReadLine());



string SecurePass(string input);
{
    bool PasswordCheck = false;
    do 
        while (input.Length is < 8 or > 64)
        {
            Console.WriteLine("Write password one more time: ");
            string passtemp = Console.ReadLine();
            if (input == passtemp)
                PasswordCheck = true;
            else
            {
                Console.WriteLine("Check spelling");
                Console.Write("Try one more time: ");
                passtemp = Console.ReadLine();
            }

        }
    while (!PasswordCheck) ;
    return input;
    
};


string CheckExisting(string input)
{
    string[] costumersLine = File.ReadAllLines("../../../Customers.csv ");
    string[] adminsLine = File.ReadAllLines("../../../Admins.csv");
    for (int i = 0; i < costumersLine.Length; i++)
    for (int k = 0; k < adminsLine.Length; k++)
    {
        string[] user = costumersLine[i].Split(",");
        string[] admin = adminsLine[k].Split(",");
        bool nonExisting=false;
        do
        {
            if (user[0] != input&& admin[0] != input)
            {
                nonExisting = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("user [- " + input + " -] already exists");
                Console.Write("Try again: ");
                input = Console.ReadLine();
            }
        }
        while (!nonExisting);
    }
    return input;
};




class NewUser
{
   //
}


 







public enum User { name, password}