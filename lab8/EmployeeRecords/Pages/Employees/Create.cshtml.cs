using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeRecords.Data;
using EmployeeRecords.Models;

namespace EmployeeRecords.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeRecords.Data.EmployeeRecordsContext _context;

        public CreateModel(EmployeeRecords.Data.EmployeeRecordsContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Options { get; set; }
        public IActionResult OnGet()
        {
            Options = _context.Department.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.DepartmentId,
                                              Text = a.DepartmentName
                                          }).ToList();
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

     

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employee.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
