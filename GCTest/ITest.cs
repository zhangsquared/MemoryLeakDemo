using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCTest
{
    public interface ITest
    {
        /// <summary>
        /// return memory usage in MB
        /// </summary>
        double Run();
    }
}
