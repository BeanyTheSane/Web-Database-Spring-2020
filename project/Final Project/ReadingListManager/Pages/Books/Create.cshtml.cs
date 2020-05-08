using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public CreateModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Authors { get; set; }
        public IList<Author> AuthorLink { get; set; }
        public List<SelectListItem> Genres { get; set; }
        public IList<Genre> GenreLink { get; set; }
        public List<SelectListItem> SeriesList { get; set; }
        public IList<Series> SeriesListLink { get; set; }
        public SelectListItem UserEmails { get; set; }
        public IActionResult OnGet()
        {
            Authors = _context.Author.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.AuthorID.ToString(),
                                              Text = a.FullName
                                          }).ToList();
            Genres = _context.Genre.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.GenreID.ToString(),
                                              Text = a.Name
                                          }).ToList();
            SeriesList = _context.Series.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.SeriesID.ToString(),
                                              Text = a.Name
                                          }).ToList();
            AuthorLink = _context.Author.ToList();
            GenreLink = _context.Genre.ToList();
            SeriesListLink = _context.Series.ToList();
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
