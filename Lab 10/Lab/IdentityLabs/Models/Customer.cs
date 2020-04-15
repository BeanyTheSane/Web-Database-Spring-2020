using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLabs.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "Name"), StringLength(256, MinimumLength = 1), Required]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9""'\s-]*$"), Display(Name = "City"), StringLength(128, MinimumLength = 3), Required]
        public string City { get; set; }
        [RegularExpression(@"^[a-zA-Z]*$"), Display(Name = "State"), StringLength(32, MinimumLength = 2), Required]
        public string State { get; set; }
        [RegularExpression(@"^[0-9-]*$"), Display(Name = "Zip Code"), StringLength(10, MinimumLength = 5), Required]
        public string Zip { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"), Display(Name = "Email"), Required]
        public string Email { get; set; }

    }
}
