using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityLabs.Data;
using IdentityLabs.Models;

namespace IdentityLabs.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public DetailsModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerId == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
