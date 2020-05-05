using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Data;
using EmployeeRecords.Models;

namespace EmployeeRecords.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRecords.Data.EmployeeRecordsContext _context;

        public IndexModel(EmployeeRecords.Data.EmployeeRecordsContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;

        public async Task OnGetAsync()
        {
            var departments = from m in _context.Department
                              select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                departments = departments.Where(s => s.DepartmentName.Contains(SearchString));
            }

            Department = await departments.ToListAsync();
        }
    }
}
