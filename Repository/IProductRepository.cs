using AzureFunctionsTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureFunctionsTutorials.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetById(long Id);
        public List<Product> Find(string name);
        public long Add(Product product);
        public long Update(Product product);
    }
}
