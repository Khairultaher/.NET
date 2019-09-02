using System;

namespace NullableType
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime? DOB = null;

            Console.WriteLine(DOB.GetValueOrDefault());
            Console.WriteLine(DOB.HasValue);
            //Console.WriteLine(DOB.Value); // Throw exception


            Console.ReadLine();
        }
    }
}
