using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Products;

/*[Authorize]*/
public class DeleteModel : PageModel
    {
        [BindProperty]
        public Product Product { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null) return NotFound();

            ProductService productService = new ProductService();
            Product = productService.GetProductbyId(id.Value);

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null) return NotFound();

            ProductService productService = new ProductService();
            productService.DeleteProduct(Product);

            return RedirectToPage("./Index");
        }
    }
