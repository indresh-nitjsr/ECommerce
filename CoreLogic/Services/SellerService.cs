using CoreLogic.Data;
using CoreLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class SellerService
    {
        private readonly MyContextDB context = new MyContextDB();
        public MyContextDB ctx;
        public SellerService()
        {
            ctx = context;
        }
        public List<Seller> GetAllSellers()
        {
            //new User(){ Id = 1, Name = "Roma", Email="roma@123", Password = "rom@#123", Address="Sitapur" , Mobile="12344556"},
            //new User(){ Id = 2, Name = "Indresh", Email="indresh@123", Password = "ind@#123", Address="Mirzapur" , Mobile="3456780"},            
            var sellers = ctx.Sellers.ToList();
            return sellers;
        }
        public void SellerRegistration(Seller seller)
        {
            ctx.Sellers.Add(seller);
            ctx.SaveChanges();
        }

        public Seller GetSeller(string email)
        {
            return ctx.Sellers.SingleOrDefault(x => x.Email == email);
        }
    }
}

