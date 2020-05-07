using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityLabs.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IdentityLabs.Data.IdentityLabsContext _context;
        public IList<SalesRep> SalesRepLink { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger, IdentityLabs.Data.IdentityLabsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGet()
        {
            SalesRepLink = await _context.SalesRep.ToListAsync();
        }
    }
}
