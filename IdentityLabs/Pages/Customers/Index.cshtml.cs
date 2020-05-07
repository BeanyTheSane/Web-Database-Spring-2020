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
    public class IndexModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;
        public IList<SalesRep> SalesRepLink { get; set; }

        public IndexModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
            SalesRepLink = await _context.SalesRep.ToListAsync();
        }
    }
}
