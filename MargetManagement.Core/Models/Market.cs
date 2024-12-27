using MargetManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MargetManagement.Core.Models
{
    public class Market:BaseEntity
    {
        public static int Mcount = 0;
        public string Name { get; set; }
        public string Address { get; set; }
        public Dictionary<Product,int> Products=new Dictionary<Product,int>();
        public Market(string name,string address)
        {
            Id = ++Mcount;
            Name = name;
            Address = address;
            Products = new Dictionary<Product,int>();
        }
        public void ShowMarket()
        {
            Console.WriteLine($"Id:{Id}, Name: {Name},Address:{Address}");
        }

    }
}
