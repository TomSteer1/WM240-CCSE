using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class Tour
    {
        public int id { get; set; }
        public string name { get; set; }
        public int length { get; set; }
        public int spaces { get; set; }
        public decimal cost { get; set; }
    }
}
