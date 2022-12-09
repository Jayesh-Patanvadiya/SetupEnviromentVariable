using System;
using System.Collections;
using System.Threading;

namespace SetupEnviromentVariable
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var data = Environment.GetEnvironmentVariable("Timer");

            //Your Code Here
            Console.WriteLine("Hello World {0}",DateTime.Now);

            int milliseconds = int.Parse(data)*60000; //300000 milliseconds = 5 minutes
            Thread.Sleep(milliseconds);
            Main(null);
        }
    }
}
