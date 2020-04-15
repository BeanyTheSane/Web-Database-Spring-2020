using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IdentityLabs.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdentityLabs.Pages.Customers
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IdentityLabs.Data.IdentityLabsContext _context;

        public CreateModel(IdentityLabs.Data.IdentityLabsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
