using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
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
            Console.Write("Please enter Username: ");
            newUser = Console.ReadLine();
            string[] usersLines = File.ReadAllLines("../../../newUser.csv");
            for (int i = 0; i < usersLines.Length; i++)
            {
                string usertemp = usersLines[i];
                string[] user = usertemp.Split(",");
                bool userNameCheck = false;
                do
                    if (newUser == user[0])
                    {
                        Console.Write(user[0] + " already exists");
                        Console.Write("Chose a diffrent username: ");
                        newUser = Console.ReadLine();
                        Console.WriteLine("-----------------");
                    }
                    else if (newUser != user[0])
                    {
                        userNameCheck = true;
                    }
                while (userNameCheck = false);
            }
            Console.Write("Please enter a secure password: ");
            newPass = Console.ReadLine();
            Console.Write("Please enter your password one more time: ");
            tempPass = Console.ReadLine();
            {
                do
                    if (newPass == tempPass)
                    {
                        PassCheck = true;
                    }
                    else if (newPass != tempPass)
                    {
                        Console.Write("WRONG! Please reenter your password: ");
                        tempPass = Console.ReadLine();
                    }
                while (PassCheck == false);
                string[] userAndPass = { newUser + "," + newPass };
                File.AppendAllLines("../../../newUser.csv", userAndPass);
            }

        }
    }
}