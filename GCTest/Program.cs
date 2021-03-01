using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    class Program
    {
        /// <summary>
        /// A is subscriber; B is publisher
        /// </summary>
        static void Main(string[] args)
        {
            ITest[] tests = new ITest[]
            {
                new Test1(), // baseline
                new Test2(), // demo for memory leak
                new Test3(), // Dispose() method on subscriber
                new Test4(), // reset event on publisher
                new Test5(), // compare with Test3, however I am using a derived class to test unsubscribe
                new Test6(), // use weak event handler with regular events
            };

            foreach (ITest t in tests)
            {
                Console.WriteLine("[x] " + t.GetType().Name);
                double remainingInMB = t.Run();
                Console.WriteLine($"Remaining memory: {remainingInMB} MB");
                if (remainingInMB > 1)
                {
                    Console.WriteLine("[!] There is a leak!!!");
                }

                Util.GCCollect();
                double clear = Util.GCUsageInMB();
                if (clear > 1)
                {
                    Console.WriteLine("Didn't clean...");
                }
                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }


}