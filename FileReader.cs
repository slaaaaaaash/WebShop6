using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop6
{
    public class FileReader
    {
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }

        public static void Printer()
        {
            string filePath = "../../../Products.csv";
            StreamReader reader = new StreamReader(filePath);
            List<FileReader> products = new List<FileReader>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length == 2)
                {
                    FileReader obj = new FileReader
                    {
                        ProductName = values[0],
                        ProductPrice = int.Parse(values[1])
                    };
                    products.Add(obj);
                }
            }
        }
    }
    //public FileReader(string filePath)
    //{
    //    Reader(filePath);
    //}

    //public List<Product> Reader(string filePath)
    //{
    //    StreamReader reader = new StreamReader(filePath);
    //    List<Product> products = new List<Product>();
    //    return products;
    //}

}
