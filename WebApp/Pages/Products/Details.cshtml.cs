using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Products;

        /*[Authorize]*/
        public class DetailsModel : PageModel
        {
            public Product Product { get; set; } = default!;

            public IActionResult OnGet(int? id)
            {
                if (id == null) return NotFound();

                ProductService productService = new ProductService();
                Product = productService.GetProductbyId(id.Value);

                if (Product == null) return NotFound();

                return Page();
            }
        }
    

