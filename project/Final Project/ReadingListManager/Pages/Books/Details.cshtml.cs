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

namespace ReadingListManager.Pages.Books
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public DetailsModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.BookID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
