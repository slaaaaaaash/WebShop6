<<<<<<< HEAD
﻿namespace WebShop6
{
    public class Product
    {

        public string ProductName;
        public int ProductPrice;
        public int ProductDate;

        public Product(string name, int price, int date)
        {
            ProductName = name;
            ProductPrice = price;
            ProductDate = date;
        }
    }
=======
﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace WebShop6;

public class Product
{
    public readonly string? Name;
    public readonly int Price;
    public readonly string? Description;


    public Product(string[] info)
    {
        Name = info[0];
        if (int.TryParse(info[1], out int value))
        {
            Price = value;
        }
        else
        {
            throw new Exception();
        }
        Description = info[2];
    }

>>>>>>> main
}