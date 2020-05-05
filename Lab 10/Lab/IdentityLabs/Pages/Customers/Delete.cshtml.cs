using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityLabs.Data;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityLabs.Pages.Customers
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public DeleteModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        public IList<SalesRep> SalesRepLink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerId == id);

            SalesRepLink = await _context.SalesRep.ToListAsync();

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FindAsync(id);

            if (Customer != null)
            {
                _context.Customer.Remove(Customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
