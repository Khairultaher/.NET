using System;
using System.Collections.Generic;

namespace GenericDelegatesFuncActionPredicate
{
    public delegate int MyDelegate(int x, int y);
    public class DelegateClass
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }
    }
    public class Program
    {

        public static void Main(string[] args)
        {

            // Delegates
            MyDelegate myDel = DelegateClass.Add;
            Console.WriteLine(myDel.Invoke(1, 2));

            // Action Delegates
            Action<string> action = new Action<string>(Display);
            action("Hello from Action Delegates");

            // Func Delegates
            Func<int, double> func = new Func<int, double>(CalculateHra);
            double funResult = func(5000);
            Console.WriteLine(funResult);

            // Predicate Delegates
            List<Customer> custList = new List<Customer>();
            custList.Add(new Customer { Id = 1, FirstName = "khairul", LastName = "alam", State = "dhaka", City = "Faridpur", Address = "Bhanga", Country = "Bangladesh" });
            custList.Add(new Customer { Id = 2, FirstName = "alam", LastName = "khairul", State = "dhaka", City = "Faridpur", Address = "Bhanga", Country = "Bangladesh" });

            Predicate<Customer> hydCustomers = x => x.Id == 3;
            Customer customer = custList.Find(hydCustomers);      
            Console.WriteLine(customer.FirstName);

            Console.ReadLine();
        }
        static void Display(string message)

        {

            Console.WriteLine(message);

        }

        static double CalculateHra(int basic)

        {

            return (double)(basic * .4);

        }

        public class Customer

        {

            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Address { get; set; }

            public string City { get; set; }

            public string State { get; set; }

            public string Country { get; set; }

        }
    }
}
