﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.UserBookList
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public CreateModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Books { get; set; }
        public IActionResult OnGet()
        {

            Books = _context.Book.Select(a =>
                                             new SelectListItem
                                             {
                                                 Value = a.AuthorID.ToString(),
                                                 Text = a.Title
                                             }).ToList();
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

            UserBookEntry.DateAdded = DateTime.Now;
            UserBookEntry.UserEmail = User.Identity.Name;
            _context.UserBookEntry.Add(UserBookEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
