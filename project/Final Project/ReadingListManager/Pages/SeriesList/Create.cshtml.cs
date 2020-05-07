using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReadingListManager.Data;
using ReadingListManager.Models;

namespace ReadingListManager.Pages.SeriesList
{
    public class CreateModel : PageModel
    {
        private readonly ReadingListManager.Data.ReadingListManagerContext _context;

        public CreateModel(ReadingListManager.Data.ReadingListManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Series Series { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Series.Add(Series);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
