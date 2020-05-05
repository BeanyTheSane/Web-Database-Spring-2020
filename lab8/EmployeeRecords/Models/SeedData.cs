using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EmployeeRecords.Data;
using System;
using System.Linq;

namespace EmployeeRecords.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmployeeRecordsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EmployeeRecordsContext>>()))
            {
                // Look for any movies.
                if (context.Employee.Any())
                {
                    return;   // DB has been seeded
                }

                context.Employee.AddRange(
                    new Employee
                    {
                        EmployeeId = "ak1234",
                        FirstName = "Adam",
                        LastName = "Knitter",
                        DepartmentId = "IT003"
                    },

                    new Employee
                    {
                        EmployeeId = "jd4756",
                        FirstName = "Jane",
                        LastName = "Doe",
                        DepartmentId = "AC002"
                    },

                    new Employee
                    {
                        EmployeeId = "cb1004",
                        FirstName = "Cortey",
                        LastName = "Blanketshop",
                        DepartmentId = "SA001"
                    },

                    new Employee
                    {
                        EmployeeId = "cc8956",
                        FirstName = "Dana",
                        LastName = "Critter",
                        DepartmentId = "SA001"
                    }
                );

                if (context.Department.Any())
                {
                    return;
                }

                context.Department.AddRange(
                    new Department
                    {
                        DepartmentId = "SA001",
                        DepartmentName = "Sales"
                    },

                    new Department
                    {
                        DepartmentId = "AC002",
                        DepartmentName = "Accounting"
                    },

                    new Department
                    {
                        DepartmentId = "IT003",
                        DepartmentName = "Internet Technologies"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}