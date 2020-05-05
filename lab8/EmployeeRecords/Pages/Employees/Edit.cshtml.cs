using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Data;
using EmployeeRecords.Models;

namespace EmployeeRecords.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly EmployeeRecords.Data.EmployeeRecordsContext _context;

        public EditModel(EmployeeRecords.Data.EmployeeRecordsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; }
        public List<SelectListItem> Options { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Options = _context.Department.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.DepartmentId,
                                              Text = a.DepartmentName
                                          }).ToList();

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.ID == id);
        }
    }
}
