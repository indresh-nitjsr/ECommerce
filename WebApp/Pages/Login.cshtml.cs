using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace WebApp.Pages;
public class LoginModel : PageModel
{
    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Here you can validate the user credentials against your database
        // Retrieve the user from your database.
        UserService userService = new UserService();
        var user = userService.GetUser(Email);

        if (user == null)
        {
            // User with the given username doesn't exist.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        if (Email != user.Email)
        {
            // Passwords don't match.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        if (Password != user.Password)
        {
            // Passwords don't match.
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }

        // User has provided valid credentials. Proceed with your login process...
        await SignInUser(user.Email);
        //var loggedInUserName = HttpContext.Session.GetString("LoggedInUserName");

        return RedirectToPage("/Index");
    }

    private async Task SignInUser(string email)
    {
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email)
        };

        var claimsIdentity = new ClaimsIdentity(claims, "CookieAuth");

        var authProperties = new AuthenticationProperties();

        await HttpContext.SignInAsync("CookieAuth", new ClaimsPrincipal(claimsIdentity), authProperties);

        //HttpContext.Session.SetString("LoggedInUserName", email);

        /*var loggedInUserNameClaim = User.FindFirst("id");
        if (loggedInUserNameClaim != null)
        {
            var LoggedInUserName = loggedInUserNameClaim.Value;
            // Use the logged-in user's name as needed
        }*/
    }
}
