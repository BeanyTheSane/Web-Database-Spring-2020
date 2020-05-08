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
    public class IndexModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public IndexModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public IList<UserBookEntry> UserBookEntry { get;set; }

        public async Task OnGetAsync()
        {
            UserBookEntry = await _context.UserBookEntry.ToListAsync();
        }
    }
}
