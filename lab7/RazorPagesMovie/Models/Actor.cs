using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Actor
    {
        public int ID { get; set; }

        [Display(Name = "Actor Id"), RegularExpression(@"^[A-Z]{2}[a-zA-Z0-9""'\s-]{6}$"), StringLength(8), Required]
        public string ActorId { get; set; }

        [Display(Name = "Last Name"), Required, StringLength(64)]
        public string LastName { get; set; }

        [Display(Name = "First Name"), Required, StringLength(64)]
        public string FirstName { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
