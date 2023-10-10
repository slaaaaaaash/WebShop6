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
            if (newUser.Length <= 0)
                do
                {
                    Console.Write("Try again: ");
                    newUser = Console.ReadLine();
                }
                while (newUser.Length <= 0);
            string[] usersLines = File.ReadAllLines("../../../newUser.csv");
            for (int i = 0; i < usersLines.Length; i++)
            {
                string usertemp = usersLines[i];
                string[] user = usertemp.Split(",");
                do
                {
                    if (newUser == user[0])
                    {
                        Console.WriteLine(user[0] + " already exists");
                        Console.Write("Chose a diffrent username: ");
                        newUser = Console.ReadLine();
                    }
                }
                while (newUser == user[0]);
            }
            int count = 1;
            do
            {
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
                    while (count <=3);
                    Console.WriteLine("");
                }
                string[] userAndPass = { newUser + "," + newPass };
                File.AppendAllLines("../../../newUser.csv", userAndPass);
            }
            while (newPass != tempPass);
        }
    }
}
