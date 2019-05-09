using System;
using System.Collections.Generic;

namespace LinqHomework
{
    public class Movie
    {
        public string Name { get; set; }

        public List<string> Genres { get; set; }

        public int LengthInMinutes { get; set; }
        
        public decimal Rating { get; set; }

        public List<Actor> Actors { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}