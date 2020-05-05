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
    }
}
