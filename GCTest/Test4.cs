using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    /// <summary>
    /// Test on weak event reference
    /// </summary>
    public class Test4 : ITest
    {
        /// <summary>
        /// I add ResetEvent() function to B's Finalizer
        /// I also manuallly called ResetEvent() 
        /// </summary>
        public double Run()
        {
            LargeObjectB b = new LargeObjectB();
            double n0 = Util.GCUsageInMB();
            CreateAs(b);
            b.TriggerEvent("1");

            b.ResetEvent();

            Util.GCCollect();
            b.TriggerEvent("2");
           
            Util.GCCollect();
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
