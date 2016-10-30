using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
	class Program
	{
	    static void Main(string[] args)
	    {
	        int[] integers = new[] {1, 2, 2, 2, 3, 3, 4, 5};
	        var numbers = integers.GroupBy(x => x);
	        string[] strings = new string[numbers.Count()];
	        int i = 0;

	        foreach (var num in numbers)
            { 
                strings[i++] = String.Format("Broj {0} ponavlja se {1}",num.Key,num.Count());
            }
            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
            Console.Read();
		}
	}
}
