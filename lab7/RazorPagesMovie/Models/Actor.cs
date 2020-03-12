using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string ActorId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}
