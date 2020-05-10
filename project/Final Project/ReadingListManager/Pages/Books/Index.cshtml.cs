using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public IndexModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public IList<Author> Author { get; set; }
        public IList<Genre> Genre { get; set; }
        public IList<Series> Series { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
            Author = await _context.Author.ToListAsync();
            Genre = await _context.Genre.ToListAsync();
            Series = await _context.Series.ToListAsync();
            foreach (Book item in Book)
            {
                item.Author = Author.Where(a => a.AuthorID.Equals(item.AuthorID)).First();
                item.Genre = Genre.Where(g => g.GenreID.Equals(item.GenreID)).First();
                item.SeriesInfo = Series.Where(s => s.SeriesID.Equals(item.SeriesInfoID)).First();
            }
        }
    }
}
