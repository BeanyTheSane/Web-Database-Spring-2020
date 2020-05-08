using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.UserBookList
{
    public class DetailsModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public DetailsModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public UserBookEntry UserBookEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserBookEntry = await _context.UserBookEntry.FirstOrDefaultAsync(m => m.UserBookEntryID == id);

            if (UserBookEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
