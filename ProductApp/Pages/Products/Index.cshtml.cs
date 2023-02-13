using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductDTOClass;
using ProductApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductApp.Pages.Products
{
    [Authorize(Policy = "RequireUserRole")]
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
