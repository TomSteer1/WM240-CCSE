using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class Booking
    {
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string userID { get; set; }
        public Decimal totalCost { get; set; }
        public bool depositPaid { get; set; } = false;
        public Decimal totalPaid { get; set; }

    }
}
