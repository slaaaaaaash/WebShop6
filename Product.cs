
using System.ComponentModel.DataAnnotations;
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
}