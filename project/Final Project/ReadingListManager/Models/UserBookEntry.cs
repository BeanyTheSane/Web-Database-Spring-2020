using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingListManager.Models
{
    public class UserBookEntry
    {
        [Key]
        public Book UserBookEntryID { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateStarted { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateRead { get; set; }
        public Boolean CurrentRead { get; set; }
    }
}
