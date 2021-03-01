using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class WeakRefA : LargeObjectA
    {
        public WeakRefA(string name) : base(name)
        {
        }

        protected override void BindEvent()
        {
            if (b != null)
            {
                b.BEvent += new WeakEventHandler<EventArgs>(OnBEvent).Handler;
            }
        }

        protected override void UnbindEvent()
        {
            // do nothing
        }

    }
}
