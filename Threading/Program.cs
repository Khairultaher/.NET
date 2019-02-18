using System;

namespace DelegatesAnonymousMethodsLambda
{
    delegate int DiscountDelegate();
    class Program
    {
        static void Main(string[] args)
        {
            //new ShoppingCart().Process(new DiscountDelegate(Calculator.Calculate));
            //new ShoppingCart().Process(new Func<bool, int>(Calculator.Calculate));
            new ShoppingCart().Process(Calculator.Calculate);
            Console.WriteLine("Press any key to continue....");
            Console.ReadLine();
        }
    }
    class Calculator
    {
        public static int Calculate(bool special)
        {
            var ok = special;
            int discount = 0;
            if (DateTime.Now.Hour < 12)
            {
                discount = 5;
            }
            else if (DateTime.Now.Hour < 20)
            {
                discount = 10;
            }
            else if (special)
            {
                discount = 20;
            }
            else
            {
                discount = 15;
            }
            return discount;
        }
    }
    class ShoppingCart
    {
        //public void Process(DiscountDelegate discount)
        //{
        //    int magicDiscount = discount();
        //    Console.WriteLine("Magic Discount is {0}",magicDiscount);
        //    Console.ReadLine();
        //}

        public void Process(Func<bool, int> discount)
        {
            int magicDiscount = discount(false);
            int magicDiscount2 = discount(true);
        }
    }
}
