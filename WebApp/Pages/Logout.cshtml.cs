using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnPostLogoutAsync()
		{
			await HttpContext.SignOutAsync(); // Perform the logout by signing out the user

			return RedirectToPage("/Index"); // Redirect the user to the home page or any other desired page
		}
	}
}
