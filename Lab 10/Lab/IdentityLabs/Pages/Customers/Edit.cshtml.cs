using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IdentityLabs.Pages.Customers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public EditModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        public List<SelectListItem> SalesReps { get; set; }
        public IList<SalesRep> SalesRepLink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.CustomerId == id);
            SalesRepLink = await _context.SalesRep.ToListAsync();
            SalesReps = _context.SalesRep.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.SalesRepID.ToString(),
                                              Text = a.FullName
                                          }).ToList();

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(Customer.CustomerId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }
    }
}
