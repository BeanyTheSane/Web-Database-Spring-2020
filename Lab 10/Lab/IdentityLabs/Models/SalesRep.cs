using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLabs.Models
{
    public class SalesRep
    {
        [Key]
        public int SalesRepID { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "First Name"), StringLength(256, MinimumLength = 1), Required]
        public string FirstName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "Last Name"), StringLength(256, MinimumLength = 1), Required]
        public string LastName { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"), Display(Name = "Email"), Required]
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
