using CoreLogic.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using CoreLogic.Models;
using System.Net;

namespace WebApp.Pages.SellerModel;

	public class SellerRegisterModel : PageModel
    {
		[BindProperty]
		public string SellerName { get; set; }

		[BindProperty]
		public string Email { get; set; }

		[BindProperty]
		public string Password { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			// Here you can validate the user credentials against your database
			// Check if the user already exists in your database.
			SellerService sellerService = new SellerService();

			var existingSeller = sellerService.GetSeller(Email);

			if (existingSeller != null)
			{
				// User with the given username already exists.
				ModelState.AddModelError(string.Empty, "Email already taken.");
				return Page();
			}

		// User has provided valid credentials. Proceed with your registration process...
		Seller newSeller = new Seller
		{
			Name = SellerName,
			Email = Email,
			Password = Password
		};
			sellerService.SellerRegistration(newSeller);

			//await SignInUser();

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

