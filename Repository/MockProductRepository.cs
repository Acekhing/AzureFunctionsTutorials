using AzureFunctionsTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsTutorials.Repository
{
    public class MockProductRepository : IProductRepository
    {

        private static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "iPhone 11 Pro Max",
                Price = 799.99M,
                Description = "Better Camera Quality",
                Category = (int)Category.Phones
            },
            new Product
            {
                Id=2,
                Name="Samsung Galaxy A72",
                Price=899.99M,
                Description= "Off to snapchat & TikTok",
                Category= (int)Category.Phones
            },
            new Product
            {
                Id = 3,
                Name = "Asus Mini Gen",
                Price = 1799.99M,
                Description = "Better Gaming console",
                Category=(int)Category.Laptop
            },
            new Product
            {
                Id=4,
                Name="Nike Air 12",
                Price=199.99M,
                Description= "Gyming is for everyone",
                Category=(int)Category.Fashion
            },
            new Product
            {
                Id = 5,
                Name = "Cobra Sweatpant",
                Price = 99.99M,
                Description = "Best for less",
                Category = (int)Category.Fashion
            },
            new Product
            {
                Id=6,
                Name="Samsung Galaxy Fold",
                Price=899.99M,
                Description= "Better for every moment",
                Category= (int)Category.Phones
            }
        };

        public List<Product> GetAll() => Products;

        public Product GetById(long Id)
        {
            var product = Products.Find(x => x.Id == Id);
            return product != null ? product : null;
        }

        public List<Product> Find(string name)
        {
            return Products.FindAll(p => p.Name.Contains(name));
        }

        public long Add(Product product)
        {
            if (product == null) return -1;

            Products.Add(product);
            return product.Id;
        }

        public long Update(Product product)
        {
            var isExist = Products.Exists(p => p.Id == product.Id);
            if (!isExist) return -1;

            Product existingProduct = Products.Find(x => x.Id == product.Id);
            Product newProduct = new Product()
            {
                Id = existingProduct.Id,
                Name = product.Name == null ?
                    existingProduct.Name : product.Name,
                Category = product.Category == 0 ?
                    existingProduct.Category : product.Category,
                Description = product.Description == null ?
                    existingProduct.Description : product.Description,
                Price = product.Price == 0 ?
                    existingProduct.Price : product.Price,
            };

            Products.Remove(existingProduct);
            Products.Add(newProduct);

            return product.Id;
        }

        public long Delete(long Id)
        {
            var isExist = Products.Exists(p => p.Id == Id);
            if (!isExist) return -1;

            Products.Remove(GetById(Id));
            return Id;
        }
    }
}
