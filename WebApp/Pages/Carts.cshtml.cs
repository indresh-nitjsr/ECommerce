using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class CartsModel : PageModel
    {
        public Cart UserCart { get; set; }
        UserService userService { get; set; }   
        public void OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                //var loggedInUserId = User.Identity.GetUserId();
                // Rest of your code that uses loggedInUserId
            }
            CartService cartService = new CartService();

            //UserCart = cartService.GetActiveCartOfUser();
        }
    }
}
