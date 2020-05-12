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

namespace ReadingListManager.Pages.UserBookList
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public DeleteModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserBookEntry = await _context.UserBookEntry.FindAsync(id);

            if (UserBookEntry != null)
            {
                _context.UserBookEntry.Remove(UserBookEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
