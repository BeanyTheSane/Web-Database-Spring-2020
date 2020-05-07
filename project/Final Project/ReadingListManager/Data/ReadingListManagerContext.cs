using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingListManager.Models;

namespace ReadingListManager.Data
{
    public class ReadingListManagerContext : DbContext
    {
        public ReadingListManagerContext (DbContextOptions<ReadingListManagerContext> options)
            : base(options)
        {
        }

        public DbSet<ReadingListManager.Models.Book> Book { get; set; }

        public DbSet<ReadingListManager.Models.Author> Author { get; set; }

        public DbSet<ReadingListManager.Models.Genre> Genre { get; set; }

        public DbSet<ReadingListManager.Models.Series> Series { get; set; }
    }
}
