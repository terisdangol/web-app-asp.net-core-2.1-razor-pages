using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Thor: Ragnarok",
                        ReleaseDate = DateTime.Parse("2017-11-3"),
                        Genre = "Science Fiction",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "The Grinch",
                        ReleaseDate = DateTime.Parse("2018-11-9"),
                        Genre = "Musical",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Night School",
                        ReleaseDate = DateTime.Parse("2018-9-28"),
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "A Star Is Born",
                        ReleaseDate = DateTime.Parse("2018-10-5"),
                        Genre = "Romance",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}