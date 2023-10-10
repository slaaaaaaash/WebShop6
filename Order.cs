using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.Collections.Generic;

namespace WebShop6;



public class Product

{

	public int Id { get; }
	public string Name { get; }
	public double Price { get; }

	public Product(int id, string name, double price)
	{
		Id = id;
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

			while (true) ;


		}
	}
}

