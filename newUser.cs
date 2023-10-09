using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop6
{
    public class newUser
    {
      public void registerNewUser()
        {
            bool freshUser = true;
            if (freshUser = true )
            {
                Console.Write("Please enter Username: ");
                string newUser = Console.ReadLine();
                Console.Write("Please enter a secure password: ");
                string newPass = Console.ReadLine();

                string userAndPass = newUser + newPass;
                //File.WriteAllLines("../../../newUser", userAndPass);
                string[] names = { "Manuel", "Arvid", "Klas", "Paulina", "Ali" };

                File.WriteAllLines("../../../newUser.csv", names);

            }
        }
    }
}
