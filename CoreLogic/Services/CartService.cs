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
    public class CartService
    {
        private readonly MyContextDB context = new MyContextDB();
        public MyContextDB ctx;
        public CartService()
        {
            ctx = context;
        }
       /* public List<User> GetAllUsers()
        {
            //new User(){ Id = 1, Name = "Roma", Email="roma@123", Password = "rom@#123", Address="Sitapur" , Mobile="12344556"},
            //new User(){ Id = 2, Name = "Indresh", Email="indresh@123", Password = "ind@#123", Address="Mirzapur" , Mobile="3456780"},            
            var users = ctx.Users.ToList();
            return users;
        }*/
        public User GetUser(string email)
        {
            return ctx.Users.SingleOrDefault(x => x.Email == email);
        }

        public List<Cart> GetActiveCartOfUser(string email)
        {
            User user = GetUser(email);
            List<Cart> cartItems = ctx.Carts.Where(x => x.User.Email == email).ToList();
            return cartItems;
        }

        public void AddItemToCart(int productId)
        {
            var prod = productId;
            
        }
    }
}
