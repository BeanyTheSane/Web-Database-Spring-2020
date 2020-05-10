using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.UserBookList
{
    public class CreateModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public CreateModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Books { get; set; }
        public List<SelectListItem> UserEmails { get; set; }
        public IActionResult OnGet()
        {
            Books = _context.Book.Select(a =>
                                             new SelectListItem
                                             {
                                                 Value = a.AuthorID.ToString(),
                                                 Text = a.Title
                                             }).ToList();
            UserEmails = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = User.Identity.Name,
                    Text = User.Identity.Name
                }
            };
            return Page();
        }

        [BindProperty]
        public UserBookEntry UserBookEntry { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.UserBookEntry.Add(UserBookEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
