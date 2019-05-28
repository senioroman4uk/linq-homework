using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    public class CustomCompare : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return object.Equals(x, y);
        }

        public int GetHashCode(int obj)
        {
            return GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            CustomDictionary<int, string> dictionary = new CustomDictionary<int, string>(new CustomCompare())
            {
                [1] = "st",
            };
            dictionary.Add(1, "str3");
            Console.WriteLine(dictionary.Count);
            dictionary.Add(2, "str");
            //dictionary.Add(2, "str3");
            Console.WriteLine(dictionary.Count);

            dictionary.Clear();
            //dictionary[1] = "str2";
            //var keys = dictionary.Keys;
            //var values = dictionary.Values;

            //foreach(var k in dictionary)
            //{
            //    Console.WriteLine("[{0}]={1}", k.Key, k.Value);
            //}
            Console.ReadKey();
        }
    }
}
