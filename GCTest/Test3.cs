﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    /// <summary>
    /// Test Dispose() function
    /// </summary>
    public class Test3 : ITest
    {
        /// <summary>
        /// I add Dispose() function to Finalizer
        /// I manuallly called Dispose() on a0
        /// but I didn't call on a1
        /// I would like to see whether the Finalizer will passively unsubscribe the event
        /// 
        /// Test result:
        /// A finalizer will not work: 
        /// the garbage collector won't call it because the event source still holds a reference to our object!
        /// </summary>
        public double Run()
        {
            LargeObjectB b = new LargeObjectB();
            double n0 = Util.GCUsageInMB();
            CreateAs(b);
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

            b.TriggerEvent("1");

            a0.Dispose();
        }

    }
}
