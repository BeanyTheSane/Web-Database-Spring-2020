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
    public class IndexModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public IndexModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }
        public IList<Book> Book { get; set; }
        public IList<Author> Author { get; set; }
        public IList<Genre> Genre { get; set; }
        public IList<Series> Series { get; set; }
        public IList<UserBookEntry> UserBookEntry { get;set; }
        public IList<UserBookItem> UserBookList { get; set; }

        public async Task OnGetAsync()
        {
            UserBookEntry = await _context.UserBookEntry.Where(ube => ube.UserEmail.Equals(User.Identity.Name)).ToListAsync();
            UserBookList = new List<UserBookItem>();

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
            foreach (UserBookEntry UBE in UserBookEntry)
            {
                UserBookItem ubi = new UserBookItem();
                ubi.title = Book.Where(b => b.BookID.Equals(UBE.BookID)).First().Title;
                ubi.author = Book.Where(b => b.BookID.Equals(UBE.BookID)).First().Author.FullName;
                ubi.seriesInfo = Book.Where(b => b.BookID.Equals(UBE.BookID)).First().SeriesInfo.Name;
                ubi.genre = Book.Where(b => b.BookID.Equals(UBE.BookID)).First().Genre.Name;
                ubi.dateAdded = UBE.DateAdded;
                ubi.userBookEntryID = UBE.UserBookEntryID;
                UserBookList.Add(ubi);
            }
        }
        public class UserBookItem
        {
            public String title { get; set; }
            public String author { get; set; }
            public DateTime dateAdded { get; set; }
            public String seriesInfo { get; set; }
            public String genre { get; set; }
            public int userBookEntryID { get; set; }

            public UserBookItem() { }
        }
    }
}
