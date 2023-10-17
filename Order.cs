using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WebShop6;
public class Order
{

		static List<Product> Products = new List<Product>();
		static List<Order> orders = new List<Order>();
		static int orderIdcounter = 1;


		static void Main()
		{
			// lägga in produkter



			Products.Add(new Product("Test", 10, ""));
			Products.Add(new Product("Name", 50, ""));
			Products.Add(new Product("Catears", 100, ""));



			{

				Console.WriteLine("1, View Order History");
				Console.WriteLine("2, Order");
				Console.WriteLine("3, Product List");




				string GetChoice(int choice)
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
							choose = "Product List";
							break;

						default:
							choose = " Invalid Choice";
							break;


					}
					return choose;
				}


				static int choice()
				{

					int choose;
					while (!int.TryParse(Console.ReadLine(), out choose))
					{

						Console.WriteLine("invalid, enter right choice");
					}

					return choose;

				}
				static void DisplayProductList()

				{
					Console.WriteLine("ProductList");

					foreach (var Product in Products)
					{
						Console.WriteLine($"{Product.Id}. {Product.Name}. {Product.Price}.");

					}

					static void Order()
					{
						DisplayProductList();
						Console.WriteLine(" Enter the Product you want");

						int product = choice();

						Product selectedProduct = null;

						foreach (Product Product in Products)
                        {
                            if (selectedProduct == Product)
                            {
                               

                            {
                               
                            }
                           



                        }

                        {

						}


					}

					
					

				}

			}
		}
	}

				
	






