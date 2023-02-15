using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductDTOClass;
using ProductApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApp.Pages.Products
{
    //[Authorize(Policy = "RequireUserRole")]
    [Authorize]
    public class DetailsModel : PageModel
    {
        public ProductDTO ProductItem { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductApiController api = new();
            var productitem = await api.GetProduct(id);
            if (productitem == null)
            {
                return NotFound();
            }
            ProductItem = productitem;

            return Page();
        }
    }
}
