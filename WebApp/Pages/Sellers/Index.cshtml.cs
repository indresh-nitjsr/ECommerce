using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages.Sellers
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Here you can validate the user credentials against your database
            // Retrieve the user from your database.
            SellerService sellerService = new SellerService();
            var seller = sellerService.GetSeller(Email);

            if (seller == null)
            {
                // User with the given username doesn't exist.
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            if (Email != seller.Email)
            {
                // Passwords don't match.
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            if (Password != seller.Password)
            {
                // Passwords don't match.
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }

            // User has provided valid credentials. Proceed with your login process...
            await SignInSeller();

            return RedirectToPage("/Products/Index");
        }

        private async Task SignInSeller()
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
