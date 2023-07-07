using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class OrderModel : PageModel
    {
        OrderService orderService = new OrderService();
        public List<Order> Orders {  get; set; }
        public void OnGet()
        {
            Orders = orderService.GetAllOrders();
        }
    }
}
