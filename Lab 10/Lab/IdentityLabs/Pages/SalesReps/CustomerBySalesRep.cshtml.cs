using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace IdentityLabs.Pages.SalesReps
{
    [Authorize]
    public class CustomerBySalesRepModel : PageModel
    {
        private readonly Data.IdentityLabsContext _context;

        public CustomerBySalesRepModel(Data.IdentityLabsContext context)
        {
            _context = context;
        }

        public IList<Models.Customer> Customers { get; set; }
        public IList<Models.SalesRep> SalesRep { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SalesRepId { get; set; }
        public IList<SalesRep> SalesRepLink { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {


            if (SalesRepId != null)
            {
                var customers = from c in _context.Customer
                                select c;

                customers = customers.Where(c => c.SalesRepID.ToString().Equals(SalesRepId));

                Customers = await customers.ToListAsync();

                var salesRep = from d in _context.SalesRep
                                 select d;


                salesRep = salesRep.Where(s => s.SalesRepID.ToString().Equals(SalesRepId));

                SalesRep = await salesRep.ToListAsync();
                SalesRepLink = await _context.SalesRep.ToListAsync();
            }
            else
            {
                return NotFound();
            }

            return Page();
        }
    }
}
