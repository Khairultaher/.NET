using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deleget
{
    class Program
    {
        public delegate int CalculatorDelegate(int firstValue, int secondValue);
        static void Main(string[] args)
        {
            //System.Predicate
            Calculator calculator = new Calculator();

            CalculatorDelegate calculatorAdd = calculator.Add;
            Console.WriteLine(calculatorAdd(10, 5));

            calculatorAdd += calculator.Subtract;
            Console.WriteLine(calculatorAdd(10, 5));

            calculatorAdd += Multiply;
            Console.WriteLine(calculatorAdd(10, 5));

            Console.ReadLine();
        }

        static int Multiply(int firstValue, int secondValue)
        {
            return firstValue * secondValue;
        }
    }

    public class Calculator
    {
        public int Add(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public int Subtract(int firstValue, int secondValue)
        {
            return firstValue - secondValue;
        }
    }
}
