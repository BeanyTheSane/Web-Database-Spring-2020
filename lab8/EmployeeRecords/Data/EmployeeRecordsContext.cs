using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeRecords.Models;

namespace EmployeeRecords.Data
{
    public class EmployeeRecordsContext : DbContext
    {
        public EmployeeRecordsContext (DbContextOptions<EmployeeRecordsContext> options)
            : base(options)
        {
        }

        public DbSet<EmployeeRecords.Models.Employee> Employee { get; set; }

        public DbSet<EmployeeRecords.Models.Department> Department { get; set; }
    }
}
