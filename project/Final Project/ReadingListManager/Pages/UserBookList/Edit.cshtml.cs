using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.UserBookList
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public EditModel(ReadingListManager.Data.ReadingListManagerContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UserBookEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserBookEntryExists(UserBookEntry.UserBookEntryID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserBookEntryExists(int id)
        {
            return _context.UserBookEntry.Any(e => e.UserBookEntryID == id);
        }
    }
}
