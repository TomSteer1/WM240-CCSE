using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class PackageBooking : Booking
    {
        [NotMapped]
        public HotelBooking hotelBooking { get; set; }
        public string hotelBookingID { get; set; }
        [NotMapped]
        public TourBooking tourBooking { get; set; }
        public string tourBookingID { get; set; }
    }
}
