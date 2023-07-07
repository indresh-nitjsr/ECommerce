using CoreLogic.Models;
using CoreLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        ProductService productService = new ProductService();
        public List<Product> products {  get; set; }    


        public void OnGet()
        {
            products = productService.GetAllProducts();
            

        }
    }
}