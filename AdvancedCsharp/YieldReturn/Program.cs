using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<int> GenerateWithoutYield()
            //{
            //    var i = 0;
            //    var list = new List<int>();
            //    while (i < 5)
            //        list.Add(++i);
            //    return list;
            //}
            //foreach (var number in GenerateWithoutYield()) 
            //{
            //    Console.WriteLine(number);
            //}



            //IEnumerable<int> GenerateWithYield()
            //{
            //    var i = 0;
            //    while (i < 5)
            //        yield return ++i;
            //}
            //foreach (var number in GenerateWithYield()) 
            //{
            //    Console.WriteLine(number);
            //}


            IEnumerable<int> GetNumbersGreaterThan3(List<int> numbers)
            {
                var theNumbers = new List<int>();
                foreach (var nr in numbers)
                {
                    if (nr > 3)
                        theNumbers.Add(nr);
                }
                return theNumbers;
            }
            foreach (var nr in GetNumbersGreaterThan3(new List<int> { 1, 2, 3, 4, 5 }))
            {
                Console.WriteLine(nr);
            }

            IEnumerable<int> GetNumbersGreaterThan3WithYield(List<int> numbers)
            {
                foreach (var nr in numbers)
                {
                    if (nr > 3) 
                    {
                        if (nr > 3)
                            yield return nr;
                    }
                      
                }
            }
            foreach (var nr in GetNumbersGreaterThan3WithYield(new List<int> { 1, 2, 3, 4, 5 }))
            {
                Console.WriteLine(nr);
            }

            Console.ReadLine();
                
        }
    }
}
