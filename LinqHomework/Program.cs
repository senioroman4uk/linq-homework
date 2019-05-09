namespace LinqHomework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // First task
            HomeWork.PrintNamesOfMoviesWithRatingLessThen8(MovieDatabase.Movies);
            
            // Second task
            HomeWork.PrintAmountOfMoviesByGenres(MovieDatabase.Movies);
            
            // Third task
            HomeWork.PrintActorsAndTheirMovies(MovieDatabase.Movies);
            
            // Fourth task
            HomeWork.PrintMoviesInOrderOfRating(MovieDatabase.Movies);
            
            // Fifth task
            HomeWork.PrintMoviesInOrderOfRating(MovieDatabase.Movies);
            
            // 6th task
            HomeWork.PrintNameOfMovieWithTheHighestRating(MovieDatabase.Movies);
            
            // 7th task
            HomeWork.PrintActorsAverageRating(MovieDatabase.Movies);
            
            // 8th task
            HomeWork.PrintAllMovieNamesInSingleLineSeparatedByComa(MovieDatabase.Movies);
            
            // 9th task
            HomeWork.PrintAreThereAnyComedyMovies(MovieDatabase.Movies);
            
            // 10th task
            HomeWork.PrintActorsWithTheLargestCountOfMovies(MovieDatabase.Movies);
        }
    }
}
