using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    /// <summary>
    /// demo for memory leak
    /// </summary>
    public class Test2 : ITest
    {
        /// <summary>
        /// Although A objects are created in a smaller function scope
        /// Both A objects are subscribed to b
        /// so a0 and a1 will not be GC-ed, causing memory leak
        /// </summary>
        public double Run()
        {
            LargeObjectB b = new LargeObjectB();
            double n0 = Util.GCUsageInMB();
            CreateAs(b);
            b.TriggerEvent("1");

            Util.GCCollect();
            b.TriggerEvent("2");
            double n1 = Util.GCUsageInMB();

            return n1 - n0;
        }

        private void CreateAs(LargeObjectB b)
        {
            LargeObjectA a0 = new LargeObjectA("a0");
            LargeObjectA a1 = new LargeObjectA("a1");
            a0.B = b;
            a1.B = b;
        }


    }
}
