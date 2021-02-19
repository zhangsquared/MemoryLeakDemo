using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class LargeObjectB
    {
        private readonly StringBuilder stringBuilder;

        public event EventHandler BEvent;

        public LargeObjectB()
        {
            stringBuilder = new StringBuilder();
            Util.BuildString(stringBuilder);

            Console.WriteLine("B constructor");
        }

        ~LargeObjectB()
        {
            Console.WriteLine("B finalizer");
        }

        public void TriggerEvent(string msg = null)
        {
            string str = "Trigger B..." + msg ?? string.Empty;
            Console.WriteLine(str);
            BEvent?.Invoke(msg, EventArgs.Empty);
        }

    }
}
