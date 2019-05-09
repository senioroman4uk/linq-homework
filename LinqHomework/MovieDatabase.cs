using System;
using System.Collections.Generic;

namespace LinqHomework
{
    public static class MovieDatabase
    {
        public static IReadOnlyCollection<Movie> Movies = new List<Movie>
        {
            new Movie
            {
                Actors = new List<Actor>
                {
                    new Actor
                    {
                        BirthDate = new DateTime(1965, 4, 4),
                        FirstName = "Robert",
                        LastName = "Downey",
                        MiddleName = "Jr."
                    },
                    new Actor
                    {
                        BirthDate = new DateTime(1972, 9, 27),
                        FirstName = "Gwyneth",
                        LastName = "Paltrow",
                        MiddleName = string.Empty
                    }
                },
                Genres = new List<string> {"Action", "Adventure", "Sci-Fi"},
                LengthInMinutes = 2 * 60 + 6,
                Name = "Iron Man",
                Rating = 7.9m,
                ReleaseDate = new DateTime(2008, 5, 2),
            },
            new Movie
            {
                Actors = new List<Actor>
                {
                    new Actor
                    {
                        BirthDate = new DateTime(1965, 4, 4),
                        FirstName = "Robert",
                        LastName = "Downey",
                        MiddleName = "Jr."
                    },
                    new Actor
                    {
                        BirthDate = new DateTime(1972, 9, 27),
                        FirstName = "Gwyneth",
                        LastName = "Paltrow",
                        MiddleName = string.Empty
                    },
                    new Actor
                    {
                        BirthDate = new DateTime(1984, 11, 22),
                        FirstName = "Scarlett",
                        LastName = "Johansson",
                        MiddleName = string.Empty
                    },
                    new Actor
                    {
                        BirthDate = new DateTime(1976, 7, 19),
                        FirstName = "Benedict",
                        LastName = "Cumberbatch",
                        MiddleName = string.Empty
                    },
                },
                Genres = new List<string> {"Action", "Adventure", "Fantasy"},
                LengthInMinutes = 181,
                Name = "Avengers: Endgame",
                Rating = 8.9m,
                ReleaseDate = new DateTime(2019, 4, 26)
            },
            new Movie
            {
                Actors = new List<Actor>
                {
                    new Actor
                    {
                        BirthDate = new DateTime(1970, 10, 8),
                        FirstName = "Matthew",
                        LastName = "Damon",
                        MiddleName = "Paige"
                    }
                },
                Genres = new List<string> {"Adventure", "Drama", "Sci-Fi"},
                LengthInMinutes = 144,
                Name = "The Martian",
                Rating = 8.0m,
                ReleaseDate = new DateTime(2015, 10, 2)
            },
            new Movie
            {
                Actors = new List<Actor>
                {
                    new Actor
                    {
                        BirthDate = new DateTime(1970, 10, 8),
                        FirstName = "Matthew",
                        LastName = "Damon",
                        MiddleName = "Paige"
                    },
                    new Actor
                    {
                        BirthDate = new DateTime(1983, 2, 23),
                        FirstName = "Emily",
                        LastName = "Blunt",
                        MiddleName = "Olivia Leah"
                    }
                },
                Genres = new List<string> {"Romance", "Sci-Fi", "Thriller"},
                LengthInMinutes = 60 + 46,
                Name = "The Adjustment Bureau",
                Rating = 7.1m,
                ReleaseDate = new DateTime(2011, 3, 4)
            },
            new Movie
            {
                Actors = new List<Actor>
                {
                    new Actor
                    {
                        BirthDate = new DateTime(1980, 12, 19),
                        FirstName = "Jacob",
                        LastName = "Gyllenhaal",
                        MiddleName = "Benjamin"
                    },
                },
                Genres = new List<string> {"Action", "Drama", "Sci-Fi"},
                LengthInMinutes = 60 + 33,
                Name = "Source Code",
                Rating = 7.5m,
                ReleaseDate = new DateTime(2011, 4, 1)
            },
            new Movie
            {
                Actors = new List<Actor>
                {
                    new Actor
                    {
                        BirthDate = new DateTime(1980, 12, 19),
                        FirstName = "Jacob",
                        LastName = "Gyllenhaal",
                        MiddleName = "Benjamin"
                    },
                },
                Genres = new List<string> {"Horror", "Sci-Fi", "Thriller"},
                LengthInMinutes = 60 + 44,
                Name = "Life",
                Rating = 6.6m,
                ReleaseDate = new DateTime(2017, 3, 24)
            }
        };
    }
}