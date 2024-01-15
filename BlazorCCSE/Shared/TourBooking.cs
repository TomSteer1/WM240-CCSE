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
        public Guid tourID { get; set; }

    }
}
