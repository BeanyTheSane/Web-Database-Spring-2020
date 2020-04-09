using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Actor> Actor { get;set; }
        [BindProperty(SupportsGet = true)]
        public string LastNameSearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FirstNameSearchString { get; set; }

        public async Task OnGetAsync()
        {

            var actors = from a in _context.Actor
                         select a;
            if (!string.IsNullOrEmpty(LastNameSearchString))
            {
                actors = actors.Where(s => s.LastName.Contains(LastNameSearchString));
            }
            if (!string.IsNullOrEmpty(FirstNameSearchString))
            {
                actors = actors.Where(s => s.FirstName.Contains(FirstNameSearchString));
            }

            Actor = await actors.ToListAsync();
        }
    }
}
