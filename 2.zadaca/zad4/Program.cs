using System;
using System.Collections.Generic;
using System.Linq;

namespace zad4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Example1(); //True
            Example2(); //1

            var universities = GetAllCroatianUniversities();

            var allCroatianStudents = universities.SelectMany(x => x.Students)
                .Distinct().Select(s => s.Name).ToArray();

            var croatianStudentsOnMultipleUniversities = universities.SelectMany(x => x.Students)
                .GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key.Name).ToArray();

            var studentsOnMaleOnlyUniversities = universities.Where(u => u.Students.All(x => x.Gender != Gender.Female))
                .SelectMany(x => x.Students)
                .Distinct()
                .Select(x => x.Name)
                .ToArray();

            Console.Out.WriteLine("All Croatian students :");
            foreach (var student in allCroatianStudents)
                if ((bool)(student != null)) Console.Out.WriteLine(student.ToString());
            Console.Out.WriteLine();

            Console.Out.WriteLine("Croatian students on multiple universities :");
            foreach (var student in croatianStudentsOnMultipleUniversities)
                if ((bool)(student != null)) Console.Out.WriteLine(student.ToString());
            Console.Out.WriteLine();

            Console.Out.WriteLine("Students on male only universities :");
            foreach (var student in studentsOnMaleOnlyUniversities)
                if ((bool)(student != null)) Console.Out.WriteLine(student.ToString());
            Console.Out.WriteLine();

            Console.Read();

            Console.ReadLine();
        }

        private static void Example1()
        {
            var list = new List<Student> { new Student("Ivan", "001234567") };
            var ivan = new Student("Ivan", "001234567");

            var anyIvanExists = list.Any(s => (bool)(s == ivan));
            Console.Out.WriteLine(anyIvanExists);
        }

        private static void Example2()
        {
            var list = new List<Student>
            {
                new Student("Ivan", "001234567"),
                new Student("Ivan", "001234567")
            };
            var distinctStudents = list.Distinct().Count();
            Console.Out.WriteLine(distinctStudents);
        }

        private static IEnumerable<University> GetAllCroatianUniversities()
        {
            var zagreb = new University { Name = "Zagreb" };
            var osijek = new University { Name = "Osijek" };
            var rijeka = new University { Name = "Rijeka" };

            var ivan = new Student("Ivan", "23", Gender.Male);
            var luka = new Student("Luka", "22", Gender.Male);
            var marko = new Student("Marko", "24", Gender.Male);
            var ana = new Student("Ana", "19", Gender.Female);
            var lucija = new Student("Lucija", "21", Gender.Female);

            zagreb.Students = new[] { ivan, luka, lucija };
            osijek.Students = new[] { marko, ana ,lucija};
            rijeka.Students = new[] { ivan, marko};

            return new[] { zagreb, osijek, rijeka };
        }
    }
}