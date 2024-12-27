using MargetManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargetManagement.Core.Models
{
    public class Product:BaseEntity
    {
        public static int count = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string name,string description,double price)
        {
            Name = name;
            Description = description;
            Price = price;
            Id = ++count;
        }
        public void PrintInfoProduct()
        {
           Console.WriteLine($"Id:{Id},Name:{Name},Description:{Description},Price:{Price}");
        }
    }
}