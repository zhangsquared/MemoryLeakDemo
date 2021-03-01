using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    /// <summary>
    /// test derived class unsubscription
    /// </summary>
    public class Test5 : ITest
    {
        /// <summary>
        /// Compare with Test3
        /// </summary>
        public double Run()
        {
            LargeObjectB b = new LargeObjectB();
            double n0 = Util.GCUsageInMB();
            CreateDerivedAs(b);
            Util.GCCollect();

            b.TriggerEvent("2");
            Util.GCCollect();
            double n1 = Util.GCUsageInMB();

            return n1 - n0;
        }

        private void CreateDerivedAs(LargeObjectB b)
        {
            LargeObjectA a0 = new DerivedA("a0");
            LargeObjectA a1 = new DerivedA("a1");
            a0.B = b;
            a1.B = b;

            b.TriggerEvent("1");

            a0.Dispose();
        }
    }

}
