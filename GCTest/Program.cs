using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest[] tests = new ITest[]
            {
                new Test1(), // baseline
                new Test2(), // demo for memory leak
                new Test3(), // Dispose() method
            };

            foreach (ITest t in tests)
            {
                double remainingInMB = t.Run();

                Console.WriteLine();
                Console.WriteLine("[x] " + t.GetType().Name);
                Console.WriteLine($"Remaining memory: {remainingInMB} MB");
                if (remainingInMB > 1)
                {
                    Console.WriteLine("There is a leak!!!");
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