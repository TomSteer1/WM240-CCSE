using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class PackageBooking : Booking
    {
        public HotelBooking hotelBooking;
        public Guid hotelBookingID;
        public TourBooking tourBooking;
        public Guid tourBookingID;
    }
}
