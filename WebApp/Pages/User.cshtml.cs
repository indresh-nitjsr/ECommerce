using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class UserModel : PageModel
    {
        UserService userService = new UserService();
        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = userService.GetAllUsers();
        }
    }
}
