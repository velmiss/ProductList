
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductDTOClass;
using ProductApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApp.Pages.Products
{
    [Authorize(Policy = "RequireAdminRole")]
    public class EditModel : PageModel
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(long id)
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            bool result = await api.PutProductItem(id, ProductItem);
            if (result)
            {
                return RedirectToPage("./Index");
            }
            return Page();


        }
    }
}
