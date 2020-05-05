using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Data;

namespace EmployeeRecords.Pages.Departments
{
    public class EmployeeByDepartmentModel : PageModel
    {

        private readonly EmployeeRecordsContext _context;

        public EmployeeByDepartmentModel (EmployeeRecordsContext context)
        {
            _context = context;
        }

        public IList<Models.Employee> Employees { get; set; }
        public IList<Models.Department> Department { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DepartmentId { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {


            if (DepartmentId != null)
            {
                var employees = from e in _context.Employee
                              select e;

                employees = employees.Where(e => e.DepartmentId.Equals(DepartmentId));

                Employees = await employees.ToListAsync();

                var department = from d in _context.Department
                                 select d;


                department = department.Where(d => d.DepartmentId.Equals(DepartmentId));

                Department = await department.ToListAsync();
            }
            else
            {
                return NotFound();
            }

            return Page();
        }
    }
}
