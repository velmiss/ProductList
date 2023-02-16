using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductDTOClass;
using ProductApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApp.Pages.Products
{

    [Authorize(Policy = "RequireAdminRole")]
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public ProductDTO ProductItem { get; set; } = new();

        ProductApiController api = new();
        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productitem = await api.GetProduct(id);
            if (productitem == null)
            {
                return NotFound();
            }
            ProductItem = productitem;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            bool result = await api.DeleteProductItem(id);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
