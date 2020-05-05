using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdentityLabs.Data;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityLabs.Pages.SalesReps
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
        public SalesRep SalesRep { get; set; }
        public IList<SalesRep> SalesRepLink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesRep = await _context.SalesRep.FirstOrDefaultAsync(m => m.SalesRepID == id);
            SalesRepLink = await _context.SalesRep.ToListAsync();

            if (SalesRep == null)
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

            _context.Attach(SalesRep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesRepExists(SalesRep.SalesRepID))
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

        private bool SalesRepExists(int id)
        {
            return _context.SalesRep.Any(e => e.SalesRepID == id);
        }
    }
}
