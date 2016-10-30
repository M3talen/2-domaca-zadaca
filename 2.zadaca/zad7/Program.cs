using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad7
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.Read();
        }

        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }

        private static int GetTheMagicNumber()
        {
            return  IKnowIGuyWhoKnowsAGuy().Result;
        }

        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            var t1 = IKnowWhoKnowsThis(10);
            var t2 = IKnowWhoKnowsThis(5);
            await Task.WhenAll(t1, t2);
            return t1.Result + t2.Result;
        }

        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }

        private static async Task<int> FactorialDigitSum(int num)
        {
            long result = num;
            for (var i = 1; i < num; i++)
                result = result * i;
            var sum = result.ToString().Sum(x => x - '0');
            return sum;
        }
    }

    
}
