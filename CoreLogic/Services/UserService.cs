using CoreLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class UserService
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>()
            {

                new User(){ Id = 1, Name = "Roma", Email="roma@123", Password = "rom@#123", Address="Sitapur" , Mobile="12344556"},
                new User(){ Id = 2, Name = "Indresh", Email="indresh@123", Password = "ind@#123", Address="Mirzapur" , Mobile="3456780"},            
            };
            return users;
        }
    }
}
