using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueExercises
{
    public class PrintJob
    {
        public string Name  { get; set; }
        public int PageCount { get; set; }

        public PrintJob(string name, int pagecount)
        {
            Name = name;
            PageCount = pagecount;
        }
    }
}
