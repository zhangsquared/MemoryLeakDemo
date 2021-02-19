using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public static class Util
    {
        public static void BuildString(StringBuilder sb, int? count = null)
        {
            int n = count ?? 1000000;
            for (int i = 0; i < n; i++)
            {
                sb.AppendLine($"[{i}] -- If you're visiting this page, you're likely here because you're searching for a random sentence. Sometimes a random word just isn't enough, and that is where the random sentence generator comes into play.");
            }
        }

        public static void GCCollect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static double GCUsageInMB()
        {
            double d = (double)GC.GetTotalMemory(true);
            return d / 1000000;
        }
    }

}
