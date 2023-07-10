using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages.Athentication
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public string UserName { get; set; }


        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string MobileNumber { get; set; }

        [BindProperty]
        public string Address { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Here you can validate the user credentials against your database
            // Check if the user already exists in your database.
            UserService userService = new UserService();

            var existingUser = userService.GetUser(Email);

            if (existingUser != null)
            {
                // User with the given username already exists.
                ModelState.AddModelError(string.Empty, "Email already taken.");
                return Page();
            }

            if (Password != ConfirmPassword)
            {
                // Passwords don't match.
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return Page();
            }

            // User has provided valid credentials. Proceed with your registration process...
            User newUser = new User
            {
                Name = UserName,
                Email = Email,
                Mobile = MobileNumber,
                Address = Address,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
            };
            userService.Register(newUser);

            //await SignInUser();

            return RedirectToPage("/Products/Index");
        }

        private async Task SignInUser()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, Email)
        };

            var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }

}
