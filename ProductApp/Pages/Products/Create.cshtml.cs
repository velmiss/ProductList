using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductApp.Data;
using ProductDTOClass;
using ProductApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApp.Pages.Products
{

    [Authorize(Policy = "RequireAdminRole")]
    public class CreateModel : PageModel
    {


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductDTO ProductItem { get; set; } = new();
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(ProductDTO ProductItem)
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            ProductApiController api = new();
            bool result = await api.PostProductItem(ProductItem);
            if (result) 
                return RedirectToPage("./Index");

            return Page();
        }
    }
}
