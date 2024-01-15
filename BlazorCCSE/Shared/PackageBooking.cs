using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class PackageBooking : HotelBooking
    {
        public HotelBooking hotelBooking;
        public TourBooking tourBooking;
    }
}
