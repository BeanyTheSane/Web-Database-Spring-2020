using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdentityLabs.Data;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityLabs.Pages.SalesReps
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public CreateModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }
        public IList<SalesRep> SalesRepLink { get; set; }

        public IActionResult OnGet()
        {
            SalesRepLink = _context.SalesRep.ToList();
            return Page();
        }

        [BindProperty]
        public SalesRep SalesRep { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesRep.Add(SalesRep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
