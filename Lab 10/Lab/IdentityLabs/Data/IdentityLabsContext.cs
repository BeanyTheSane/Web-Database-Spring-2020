using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IdentityLabs.Models;

namespace IdentityLabs.Data
{
    public class IdentityLabsContext : DbContext
    {
        public IdentityLabsContext (DbContextOptions<IdentityLabsContext> options)
            : base(options)
        {
        }

        public DbSet<IdentityLabs.Models.Customer> Customer { get; set; }

        public DbSet<IdentityLabs.Models.SalesRep> SalesRep { get; set; }
    }
}
