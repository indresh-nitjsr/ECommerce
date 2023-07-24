using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        ProductService productService = new ProductService();
        public List<Product> products {  get; set; }    
        public List<CartItem> cartItems { get; set; }
        public void OnGet()
        {
            products = productService.GetAllProducts();          
        }
        public IActionResult OnPost()
        {
            var productId = products.FirstOrDefault();
            if (productId == null)
            {
                return NotFound();
            }
            //Product product = productService.GetProductbyId();
            return RedirectToPage("Carts");
        }
    }
}