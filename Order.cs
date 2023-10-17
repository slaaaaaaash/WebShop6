using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WebShop6;



public class Product

{

	public int product { get; }
	public string Name { get; }
	public double Price { get; }

	public Product(int product, string name, int price)
	{
		product = product;
		Name = name;
		Price = price;
	}



	public class Order
	{
		static List<Product> products = new List<Product>();
		static List<Order> orders = new List<Order>();
		static int orderIdcounter = 1;


		static void Main()
		{
			// lägga in produkter

			products.Add(new Product(1, "Test", 10));
			products.Add(new Product(2, "Name", 50));
			products.Add(new Product(3, "Catears", 100));

		

			{

				Console.WriteLine("1, View Order History");
				Console.WriteLine("2, Order");
				Console.WriteLine("3, Product List");

				static string GetChoice(int choice) {

					string choose;

					switch (choice)
					{
						case 1:
							choose = "View Order History";
							break;
                        case 2:
							choose = "Order";
                            break;
                        case 3:
                            choose = "Product List";
                            break;
						default:
							choose = " Invalid Choice";
							break;


                    }
					return choose;
				}


				

				{
					




					}
				}
			}
		}
	}





