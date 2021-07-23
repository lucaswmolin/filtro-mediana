using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCT2
{
    public class Score
    {
        public string path { get; set; }
        public long readFile { get; set; }
        public long threadTime { get; set; }
        public long writeFile { get; set; }
        public long totalTime { get; set; }
    }
}
