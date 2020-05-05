using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingListManager.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Series> Series { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
} 
