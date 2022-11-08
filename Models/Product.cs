using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsTutorials.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Category { get; set; }
    }

    public enum Category
    {
        Phones,
        Fashion,
        Laptop,
        Accessories
    }
}
