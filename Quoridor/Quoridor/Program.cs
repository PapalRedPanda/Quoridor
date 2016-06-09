using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quoridor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int firstVar = 1;
            Add(firstVar, 89);
            Console.ReadLine(); //Here just so we can see the output box before it disappears
        }

        public static void Add(int a, int b)
        {
            Console.WriteLine("Can you not add {0} + {1} on your own? Sheesh.\n\n\n(It's {2} by the way)", a, b, a+b);
        }
    }
}
