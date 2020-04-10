using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Data;
using EmployeeRecords.Models;

namespace EmployeeRecords.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeRecords.Data.EmployeeRecordsContext _context;

        public DetailsModel(EmployeeRecords.Data.EmployeeRecordsContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employee.FirstOrDefaultAsync(m => m.ID == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
