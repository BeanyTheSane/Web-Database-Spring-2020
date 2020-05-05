using IdentityLabs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLabs.Models
{
    public static class SeedData
    {
        public static void Initialize(IdentityLabsContext context)
        {
            if (!context.SalesRep.Any())
            {
                var salesReps = new SalesRep[]
                {
                    new SalesRep
                        {
                            FirstName = "Cloud",
                            LastName = "Strife",
                            Email = "c.strife@shinra.com"
                        },

                        new SalesRep
                        {
                            FirstName = "Tifa",
                            LastName = "Lockhart",
                            Email = "t.Lockhart@shinra.com"
                        }
                };

                foreach (SalesRep rep in salesReps)
                {
                context.SalesRep.Add(rep);
                }
                context.SaveChanges();

                if (!context.Customer.Any())
                {
                    var customers = new Customer[]
                    {
                            new Customer
                            {
                                Name = "Adam Knitter",
                                City = "South Amherst",
                                State = "Ohio",
                                Zip = "44001",
                                Email = "knitter0288@gmail.com",
                                SalesRepID = salesReps.Single( r => r.FirstName == "Cloud").SalesRepID
                            },

                            new Customer
                            {
                                Name = "John Smith",
                                City = "Avon Lake",
                                State = "Ohio",
                                Zip = "44011",
                                Email = "john.smith@example.com",
                                SalesRepID = salesReps.Single( r => r.FirstName == "Tifa").SalesRepID
                            },

                            new Customer
                            {
                                Name = "Luke Skywalker",
                                City = "Mos Eisley",
                                State = "Tatooine",
                                Zip = "48514",
                                Email = "luke.skywalker@holo.net",
                                SalesRepID = salesReps.Single( r => r.FirstName == "Cloud").SalesRepID
                            }
                    };

                    foreach (Customer c in customers)
                    {
                        context.Customer.Add(c);
                    }
                    context.SaveChanges();
                }
            }
            else return;
        }
    }
}
