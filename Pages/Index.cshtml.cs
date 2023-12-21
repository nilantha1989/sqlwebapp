using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlwebapp.Services;

namespace sqlwebapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Models.Product> Products;
        public void OnGet()
        {
            ProductService productService = new ProductService();
            Products=productService.GetProducts();
        }
    }
}