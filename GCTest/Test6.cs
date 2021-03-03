using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class Test6 : ITest
    {
        /// <summary>
        /// https://paulstovell.com/weakevents/
        /// https://michaelscodingspot.com/5-techniques-to-avoid-memory-leaks-by-events-in-c-net-you-should-know/
        /// https://ladimolnar.com/2015/09/14/the-weak-event-pattern-is-dangerous/
        /// https://www.codeproject.com/Articles/29922/Weak-Events-in-C
        /// It is good, but it's random and unreliable
        /// </summary>
        /// <returns></returns>
        public double Run()
        {
            LargeObjectB b = new LargeObjectB();
            double n0 = Util.GCUsageInMB();
            CreateAs(b);
            Util.GCCollect();

            b.TriggerEvent("2"); // result: a0 and a1 will NOT respond here
            Util.GCCollect();
            double n1 = Util.GCUsageInMB();

            return n1 - n0;
        }

        private void CreateAs(LargeObjectB b)
        {
            LargeObjectA a0 = new WeakRefA("a0");
            LargeObjectA a1 = new WeakRefA("a1");
            a0.B = b;
            a1.B = b;

            b.TriggerEvent("1");

            Util.GCCollect();

            b.TriggerEvent("1.1"); // result: a0 and a1 will still respond here
        }

    }
}
