using CoreLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class ProductService
    {
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1, Category = "Mobile", Description = "6GB RAM 128GB Strorage Snapdragon processor" ,ProductName = "OnePlus 9 pro" , Price = 31000 , Qunatity=1},
                new Product { Id = 2, Category = "Laptop", Description = "8GB RAM 1TB Strorage OctaCore processor" ,ProductName = "MacBook" , Price = 80000 , Qunatity=2},
            };
            return products;
        }
    }
}
