using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WebShop6;

public class newUser
{
    public static void registerNewUser()
    {
        bool freshUser = true;
        bool PassCheck = false;
        string newPass, newUser, tempPass;
        if (freshUser = true)
        {
            Console.WriteLine("To return to previous meny, press ESC.");
            Console.WriteLine();
            Console.WriteLine("Otherwise, press any key to log in");
            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
                Console.Write("Please enter Username: ");
                newUser = Console.ReadLine();


                if (newUser.Length <= 0)
                    do
                    {
                        Console.Write("Try again: ");
                        newUser = Console.ReadLine();
                    }
                    while (newUser.Length <= 0);
                do
                    if (Login.ValidateUsername(newUser))
                    {
                        Console.Clear();
                        Console.WriteLine("Welcome to the Time-travelling Feline");
                        Console.Write(newUser + " exist try again: ");
                        newUser = Console.ReadLine();
                    }
                while (Login.ValidateUsername(newUser));
                int count = 1;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Please enter Username: " + newUser);
                    Console.Write("Please enter a secure password: ");
                    newPass = Login.MaskedPass();
                    Console.WriteLine("");
                    Console.Write("Please enter your password one more time: ");
                    tempPass = Login.MaskedPass();
                    if (newPass != tempPass)
                    {
                        do
                        {
                            Console.WriteLine("");
                            Console.Write("WRONG! Please reenter your password: " + count + "  / 3 attempt: ");
                            tempPass = Login.MaskedPass();
                            count++;
                        }
                        while (count <= 3);
                        Console.WriteLine("");
                    }
                    string[] userAndPass = { newUser + "," + newPass };
                    File.AppendAllLines("../../../newUser.csv", userAndPass);
                }
            while (newPass != tempPass);
        }
    }
}

    

