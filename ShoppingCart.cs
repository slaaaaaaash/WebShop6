using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop6
{
    public class ShoppingCart

    {
        public static void EditCart()
        {
            //Displayar innehållet av varukorgen
            int nr = 1;
            foreach (var item in FileReader.products)
            {
                Console.WriteLine($"{nr++}. {item.ProductName}, {item.ProductPrice};-");
            }

        }
        public static int TotalPrice()
        {
            var totalprice = FileReader.products.Select(product => product.ProductPrice).Sum();
            return totalprice;
        }
        public static void CartMenu() //visa totala beställning
        {
            Console.Clear();
            Console.WriteLine("1. Ta bort");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    EditCart();
                    break;

                default://tillbaka menyval för kunden
                    Customer.CustomerMenu(username);
                    break;

            }
            //loopa>hämta produktinfo
            Console.WriteLine($" Total =  {TotalPrice()} "); //anropa en beräkningsfunktion av totalsumman
        }
    }
}