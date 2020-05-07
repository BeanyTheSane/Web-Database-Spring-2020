using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingListManager.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
        public int AuthorID { get; set; }
        public int SeriesInfoID { get; set; }
        public int GenreID { get; set; }
        public Author Author { get; set; }
        public Series SeriesInfo { get; set; }
        public Genre Genre { get; set; }

    }
} 
