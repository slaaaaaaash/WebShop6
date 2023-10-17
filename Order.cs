using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WebShop6;



public class Products 

{

	public int Productss { get; }
	public string Name { get; }
	public double Price { get; }

	public Products(int Products, string name, int price)
	{
		Products = Products;
		Name = name;
		Price = price;
	}



	public class Order
	{
		static List<Products> Products = new List<Products>();
		static List<Order> orders = new List<Order>();
		static int orderIdcounter = 1;


		static void Main()
		{
			// lägga in produkter

			Products.Add(new Products(1, "Test", 10));
			Products.Add(new Products(2, "Name", 50));
			Products.Add(new Products(3, "Catears", 100));



			{

				Console.WriteLine("1, View Order History");
				Console.WriteLine("2, Order");
				Console.WriteLine("3, Productss List");

				static string GetChoice(int choice)
				{

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
							choose = "Productss List";
							break;
						default:
							choose = " Invalid Choice";
							break;


					}
					return choose;
				}

				


				}
				

				{
					




					}
				}
			}
		}
	





