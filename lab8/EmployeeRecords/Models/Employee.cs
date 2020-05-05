using System.ComponentModel.DataAnnotations;

namespace EmployeeRecords.Models
{
    public class Employee
    {
        public int ID { get; set; }

        [RegularExpression(@"^[a-z]{2}[0-9]{4}$"), Display(Name = "Employee Id"), StringLength(6, MinimumLength = 6), Required]
        public string EmployeeId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "First Name"), StringLength(64, MinimumLength = 1), Required]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "Last Name"), StringLength(64, MinimumLength = 1), Required]
        public string LastName { get; set; }

        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }
    }
}
