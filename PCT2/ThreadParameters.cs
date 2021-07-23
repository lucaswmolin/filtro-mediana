using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT2
{
    public class ThreadParameters
    {
        public int start { get; set; }
        public int end { get; set; }

        public ThreadParameters(int pStart, int pEnd)
        {
            start = pStart;
            end = pEnd;
        }
    }
}
