using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqHomework
{
    public static class HomeWork
    {
        // Example of output:
        // The Adjustment Bureau
        // Iron Man
        public static void PrintNamesOfMoviesWithRatingLessThen8(IReadOnlyCollection<Movie> movies)
        {
            var result = movies.Where(movie => movie.Rating < 8).Select(movie => movie.Name);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }
        }
        
        // Example of output:
        // { Genre = Action, Count = 2 }
        // { Genre = Adventure, Count = 3 }
        public static void PrintAmountOfMoviesByGenres(IReadOnlyCollection<Movie> movies)
        {
            var genres = movies.SelectMany(m => m.Genres, (movie, genre) => new
            {
                movie.Name,
                genre
            }).GroupBy(g => g.genre, g => g.Name);
            foreach( var genre in genres)
            {
                Console.WriteLine("{{ Genre = {0}, Count = {1} }}", genre.Key, genre.Count());
            }
        }
        
        // Example of output
        // Mat Daemon 2
        // Robert Dawney Jr. 2
        // etc.
        public static void PrintActorsAndTheirMovies(IReadOnlyCollection<Movie> movies)
        {
            var actors = movies.SelectMany(m => m.Actors, (movie, actor) => new
            {
                movie.Name,
                actor
            }).GroupBy(a => new
            {
                a.actor.FirstName,
                a.actor.LastName
            }, a => a.Name);
            foreach(var actor in actors)
            {
                Console.WriteLine("{0} {1} {2}", 
                    actor.Key.FirstName, 
                    actor.Key.LastName, 
                    actor.Count());
            }
        }
        
        // The Adjustment Bureau 7.1
        // Iron Man 
        public static void PrintMoviesInOrderOfRating(IReadOnlyCollection<Movie> movies)
        {
            var result = movies.OrderBy(m => m.Rating);
            foreach(var item in result)
            {
                Console.WriteLine("{0} {1}", item.Name, item.Rating);
            }
        }

        public static void PrintNameOfMovieWithTheHighestRating(IReadOnlyCollection<Movie> movies)
        {
            var result = movies.OrderByDescending(m => m.Rating).First().Name;
            Console.WriteLine(result);
        }
        
        // Mat Daemon 7.5
        // Robert Dawney Jr. 6.5
        // average means average rating of all movies for the actor
        public static void PrintActorsAverageRating(IReadOnlyCollection<Movie> movies)
        {
            var result = movies.SelectMany(m => m.Actors, (movie, actor) => new
            {
                actor,
                movie.Rating
            }).GroupBy(a => new
            {
                a.actor.LastName,
                a.actor.FirstName
            });
            foreach(var item in result)
            {
                Console.WriteLine("{0} {1} {2}", 
                    item.Key.FirstName, 
                    item.Key.LastName, 
                    item.Average(i => i.Rating));
            }
        }
        
        // Iron Man, Avengers, ....
        public static void PrintAllMovieNamesInSingleLineSeparatedByComa(IReadOnlyCollection<Movie> movies)
        {
            var result = movies.Select(m => m.Name)
                            .Aggregate((m1, m2) => m1 + ", " + m2);
            Console.WriteLine(result);
        }


        // Example of output "Yes"/ "No"
        public static void PrintAreThereAnyComedyMovies(IReadOnlyCollection<Movie> movies)
        {
            bool result = movies.Any(m => m.Genres.Any(g => g == "Comedy"));
            Console.WriteLine(result ? "Yes" : "No");
        }

        // Robert Dawney Jr 2
        // Jake  Gyllenhaal 2
        public static void PrintActorsWithTheLargestCountOfMovies(IReadOnlyCollection<Movie> movies)
        {
            var actors = movies.SelectMany(m => m.Actors, (movie, actor) => new
            {
                movie.Name,
                actor
            }).GroupBy(a => new
            {
                a.actor.FirstName,
                a.actor.LastName
            }, a => a.Name);

            var maxCount = actors.Max(a => a.Count());
            var result = actors.Where(
                a => a.Count() == maxCount);

            foreach( var item in result)
            {
                Console.WriteLine("{0} {1} {2}", 
                    item.Key.FirstName, 
                    item.Key.LastName, 
                    item.Count());
            }
        }
    }
}