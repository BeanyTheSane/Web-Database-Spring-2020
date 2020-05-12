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

namespace ReadingListManager.Pages.Genres
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public DetailsModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Genre = await _context.Genre.FirstOrDefaultAsync(m => m.GenreID == id);

            if (Genre == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
