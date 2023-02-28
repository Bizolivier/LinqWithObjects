using System;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program {
        static void Main(string[] args) {

            string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };


            Console.WriteLine("Deferred execution ");

            //which names ends with M

            var query1 = names.Where(name => name.EndsWith("m"));

           foreach(var name in query1) {

                Console.WriteLine(name);
            }
            //which names ends with M 
            // written using Linq query comprenhension syntax

            var query2 = from name in names where name.EndsWith("m")select name;

            var query = names.Where(new Func<string, bool>(NameLongerThanFour));

            //Optimaze solution

            var query3 = names.Where(NameLongerThanFour);

            foreach (var name in query) {


                Console.WriteLine(name);
            }

            Console.WriteLine("**********************************************************");

            //ThenBy ordonne par ordre alphabetic

            IOrderedEnumerable<string> query5 = names.Where(name => name.Length > 4 )
                              .OrderBy(name => name.Length)
                              .ThenBy(name => name);
                              

            Console.WriteLine("Names longuer than four letters and order by length");


            Console.WriteLine("**********************************************************");

            foreach (var name in query5) {
                
                
                Console.WriteLine(name);
            }
            Console.WriteLine("*************************  Filtering by type   *********************************");

            

            List<Exception> exceptions = new (){ new ArgumentException(),
                                                              new SystemException(),
                                                              new IndexOutOfRangeException(),
                                                              new InvalidOperationException(),
                                                              new NullReferenceException(),
                                                              new OverflowException(),
                                                              new DivideByZeroException(),
                                                              new ApplicationException()
            };

            IEnumerable<ArithmeticException> arithmeticExceptionQuery = exceptions.OfType<ArithmeticException>();

            foreach(var exec in arithmeticExceptionQuery) {
                Console.WriteLine(exec);
            }

        }

        static bool NameLongerThanFour(string name) {
            return name.Length > 4;
        }
    }
}