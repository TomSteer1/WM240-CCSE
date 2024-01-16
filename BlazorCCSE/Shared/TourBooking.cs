using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class TourBooking : Booking
    {
        public Tour? tour {  get; set; }
        public string tourID { get; set; }
        public int people { get; set; } = 1;
        public string? packageID { get; set; }
    }
}
