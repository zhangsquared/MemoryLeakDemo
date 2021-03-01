using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class DerivedA : LargeObjectA
    {
        public DerivedA(string name) : base(name)
        {
        }

        protected override void OnBEvent(object sender, EventArgs e)
        {
            string str = sender?.ToString() ?? string.Empty;
            Console.WriteLine($"...derived {name} responded for {str}");
        }
    }
}
