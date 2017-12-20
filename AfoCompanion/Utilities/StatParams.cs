using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AfoCompanion.Utilities
{
    public class StatParams
    {
        public long TS { get; set; }
        public string Name { get; set; }

        public StatParams(long time, string n)
        {
            this.TS = time;
            this.Name = n;
        }
    }
}