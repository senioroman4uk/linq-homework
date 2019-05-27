using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Linq2GitHub
{
    public class Programmer
    {
        public string Name { get; set; }
        public int Course { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Implement IQueryable provider that uses github rest api for querying repositories
            // See https://developer.github.com/v3/repos/#list-user-repositories
            // Should support sorting by `created, updated, pushed, full_name`
            // Should support sort direction
            // Should support filtering by type
            // In other cases should throw not implemented
            var programmers = new List<Programmer>()
            {
                new Programmer() {Name = "Kate", Course = 5},
                new Programmer() {Name="Sveta", Course = 2}
            };
            var result = programmers.AsQueryable().OrderBy(programmer => programmer.Course);            

            var query = new GitQueryable(
                new GitQueryProvider(
                    new QueryTranslator()), 
                    null);
            var test = from element in query
                    select element;
            var list = test.ToList();
            Console.ReadKey();
        }
    }
}