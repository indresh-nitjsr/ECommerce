using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }
        
        public void OnGetAsync()
        {
            ProductService productService = new ProductService();
            Products = productService.GetAllProducts();
        }
    }
}
