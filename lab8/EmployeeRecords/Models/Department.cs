using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRecords.Models
{
    public class Department
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]{2}[0-9]{3}$"), Display(Name = "Department Id"), StringLength(5, MinimumLength = 5), Required]
        public String DepartmentId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "Department Name"), StringLength(64, MinimumLength = 3), Required]
        public String DepartmentName { get; set; }
    }
}
