using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public class LargeObjectA : IDisposable
    {
        private readonly string name;
        private readonly StringBuilder stringBuilder;
        private LargeObjectB b;

        public LargeObjectA(string name)
        {
            this.name = name;
            stringBuilder = new StringBuilder();
            Util.BuildString(stringBuilder);

            Console.WriteLine($"{name} constructor");
        }

        ~LargeObjectA()
        {
            Dispose();
            Console.WriteLine($"{name} finalizer");
        }

        public LargeObjectB B
        {
            get => b;
            set
            {
                UnbindEvent();
                b = value;
                BindEvent();
            }
        }

        private void BindEvent()
        {
            if (b != null)
                b.BEvent += OnBEvent;
        }

        private void UnbindEvent()
        {
            if (b != null)
                b.BEvent -= OnBEvent;
        }

        private void OnBEvent(object sender, EventArgs e)
        {
            string str = sender?.ToString() ?? string.Empty;
            Console.WriteLine($"...{name} responded for {str}");
        }

        #region IDisposable
        public void Dispose()
        {
            Console.WriteLine($"{name} dispose");
            UnbindEvent();
        }
        #endregion
    }
}