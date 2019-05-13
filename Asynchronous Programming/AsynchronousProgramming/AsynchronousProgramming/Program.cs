using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Task a = AsyncMethodWithoutReturnType(); //Task started for Execution and immediately goes to Line 19 of the code. Cursor will come back as soon as await operator is met		
            Console.WriteLine("Cursor Moved to Next Line Without Waiting for MyMethodAsync() completion");
            Console.WriteLine("Now Waiting for Task to be Finished");
            //Task.WaitAll(a); //Now Waiting		

            Console.WriteLine("Press any key to exit....");
            Console.ReadLine();
        }

        public static async Task AsyncMethodWithoutReturnType()
        {
            Task<int> longRunningTask = AsyncMethodWithReturnType();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here
            Console.WriteLine("Independent Works of now executes in AsyncMethodWithReturnType()");
            //and now we call await on the task 
            int result = await longRunningTask;
            //use the result 
            Console.WriteLine("Result of AsyncMethodWithReturnType() is " + result);


        }
        public static async Task<int> AsyncMethodWithReturnType()
        {
            Console.WriteLine("AsyncMethodWithReturnType is started...");
            await Task.Delay(2000); // wait for two second
            Console.WriteLine("AsyncMethodWithReturnType is finished...");
            return 1;
        }

    }
}
