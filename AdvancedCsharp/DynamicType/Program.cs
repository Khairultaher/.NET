using System;

namespace DynamicType
{
    class Program
    {
        static void Main(string[] args)
        {
            object objKhairul = "Khairul";
            var methodInfo = objKhairul.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null,null);


            Console.ReadLine();
        }
    }
}
