using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Pages.Products;
    public class CreateModel : PageModel
    {
        private ProductService productService;

        [BindProperty]
        public Product Product { get; set; } = default!;

        public CreateModel()
        {
            productService = new ProductService();
        }

        public IActionResult OnGet()
        {
            var categories = productService.GetAllProducts();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Product == null)
            {
                return Page();
            }
            productService.AddProduct(Product);
            return RedirectToPage("./Index");
        }
    }