﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                );

                if (context.Actor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Actor.AddRange(
                    new Actor
                    {
                        ActorId = "BM459632",
                        LastName = "Murray",
                        FirstName = "Bill",
                        BirthDate = DateTime.Parse("1950-9-21")
                    },

                    new Actor
                    {
                        ActorId = "DA632894",
                        LastName = "Aykroyd",
                        FirstName = "Dan",
                        BirthDate = DateTime.Parse("1952-7-01")
                    },

                    new Actor
                    {
                        ActorId = "BC821145",
                        LastName = "Crystal",
                        FirstName = "Billy",
                        BirthDate = DateTime.Parse("1948-3-14")
                    },

                    new Actor
                    {
                        ActorId = "JW358564",
                        LastName = "Wayne",
                        FirstName = "John",
                        BirthDate = DateTime.Parse("1907-5-26")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}