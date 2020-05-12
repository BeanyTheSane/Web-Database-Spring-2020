using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.SeriesList
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public IndexModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public IList<Series> Series { get;set; }

        public async Task OnGetAsync()
        {
            Series = await _context.Series.ToListAsync();
        }
    }
}
