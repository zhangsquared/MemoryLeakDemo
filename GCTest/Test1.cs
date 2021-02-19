using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    /// <summary>
    /// Baseline
    /// </summary>
    public class Test1 : ITest
    {
        /// <summary>
        /// Create B first in a larger scope
        /// then create 2 A objects in a function.
        /// those 2 A objects should be GC-ed outside of CreateAs() function
        /// </summary>
        public double Run()
        {
            LargeObjectB b = new LargeObjectB();
            double n0 = Util.GCUsageInMB();
            CreateAs();
            Util.GCCollect();
            double n1 = Util.GCUsageInMB();
            return n1 - n0;
        }

        private void CreateAs()
        {
            LargeObjectA a0 = new LargeObjectA("a0");
            LargeObjectA a1 = new LargeObjectA("a1");
        }

    }

}
