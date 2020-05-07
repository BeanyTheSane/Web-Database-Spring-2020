using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.SeriesList
{
    public class DetailsModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public DetailsModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public Series Series { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Series = await _context.Series.FirstOrDefaultAsync(m => m.SeriesID == id);

            if (Series == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
