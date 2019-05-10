using System;

namespace LinqHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // First task
            HomeWork.PrintNamesOfMoviesWithRatingLessThen8(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // Second task
            HomeWork.PrintAmountOfMoviesByGenres(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // Third task
            HomeWork.PrintActorsAndTheirMovies(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // Fourth task
            HomeWork.PrintMoviesInOrderOfRating(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // Fifth task
            HomeWork.PrintMoviesInOrderOfRating(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // 6th task
            HomeWork.PrintNameOfMovieWithTheHighestRating(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // 7th task
            HomeWork.PrintActorsAverageRating(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // 8th task
            HomeWork.PrintAllMovieNamesInSingleLineSeparatedByComa(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // 9th task
            HomeWork.PrintAreThereAnyComedyMovies(MovieDatabase.Movies);

            Console.WriteLine(new String('-', 50));
            // 10th task
            HomeWork.PrintActorsWithTheLargestCountOfMovies(MovieDatabase.Movies);
        }
    }
}
