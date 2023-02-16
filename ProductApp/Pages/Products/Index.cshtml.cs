using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductDTOClass;
using ProductApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApp.Pages.Products
{
    //[Authorize(Policy = "RequireUserRole")]
    //require loged in user
    [Authorize]
    public class IndexModel : PageModel
    {
        public IList<ProductDTO> ProductItem { get; set; } = new List<ProductDTO>();

        public async Task OnGetAsync()
        {
            ProductApiController api = new();
            ProductItem = await api.GetProducts();
        }
    }
}
