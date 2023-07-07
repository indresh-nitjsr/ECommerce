using Azure;
using CoreLogic.Data;
using CoreLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class ProductService
    {
        private readonly MyContextDB context = new MyContextDB();
        public MyContextDB ctx; 
        public ProductService()
        {   
            ctx = context;
        }
        public List<Product> GetAllProducts()
        {
            //new Product { Id = 1, Category = "Mobile", Description = "6GB RAM 128GB Strorage Snapdragon processor" ,ProductName = "OnePlus 9 pro" , Price = 31000 , Qunatity=1},
            //new Product { Id = 2, Category = "Laptop", Description = "8GB RAM 1TB Strorage OctaCore processor" ,ProductName = "MacBook" , Price = 80000 , Qunatity=2},
            var products = ctx.Products.ToList();
            return products;
        }

        public void AddProduct(Product product) 
        {
            ctx.Products.Add(product);
            ctx.SaveChanges();
        }

        public void UpdateProduct(Product product) 
        {
            ctx.Products.Update(product);
            ctx.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            ctx.Products.Remove(product);
            ctx.SaveChanges();
        }

        public Product GetProductbyId(int id)
        {
            return ctx.Products.Single(p => p.Id == id);
        }
    }
}
