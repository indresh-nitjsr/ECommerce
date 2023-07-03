using CoreLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class OrderService
    {
        public List<Order> GetAllOrders()
        {
            var orders = new List<Order>()
            {
                new Order() { Id = 1, ProductId = 2, UserId = 1 },
                new Order() { Id = 2, ProductId = 1, UserId = 2 },
            };
            return orders;
        }

    }
}
