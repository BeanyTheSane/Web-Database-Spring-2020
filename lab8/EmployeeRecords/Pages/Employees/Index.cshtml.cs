using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Data;
using EmployeeRecords.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRecords.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeRecords.Data.EmployeeRecordsContext _context;

        public IndexModel(EmployeeRecords.Data.EmployeeRecordsContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        [BindProperty(SupportsGet = true)]
        public string FirstNameSearchString { get; set; }

        public SelectList Departments { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Department { get; set; }
        public List<SelectListItem> Options { get; set; }

        public async Task OnGetAsync()
        {

            Options = _context.Department.Select(a =>
                                          new SelectListItem
                                          {
                                              Value = a.DepartmentId,
                                              Text = a.DepartmentName
                                          }).ToList();

            IQueryable<string> genreQuery = from m in _context.Employee
                                            orderby m.DepartmentId
                                            select m.DepartmentId;

            var employees = from m in _context.Employee
                         select m;
            if (!string.IsNullOrEmpty(FirstNameSearchString))
            {
                employees = employees.Where(s => s.FirstName.Contains(FirstNameSearchString));
            }

            if (!string.IsNullOrEmpty(Department))
            {
                employees = employees.Where(x => x.DepartmentId == Department);
            }

            Departments = new SelectList(await genreQuery.Distinct().ToListAsync());
            Employee = await employees.ToListAsync();
        }
    }
}
