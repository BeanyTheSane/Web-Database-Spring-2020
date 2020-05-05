using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace IdentityLabs.Pages.Customers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public CreateModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        public List<SelectListItem> SalesReps { get; set; }
        public IList<SalesRep> SalesRepLink { get; set; }
        public IActionResult OnGet()
        {
            SalesReps = _context.SalesRep.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.SalesRepID.ToString(),
                                              Text = a.FullName
                                          }).ToList();
            SalesRepLink = _context.SalesRep.ToList();
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

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
