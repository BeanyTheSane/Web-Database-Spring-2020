using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdentityLabs.Data;
using IdentityLabs.Models;

namespace IdentityLabs.Pages.SalesReps
{
    public class DetailsModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public DetailsModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

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
    }
}
