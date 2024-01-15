using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public enum RoomTypes
    {
        [Description ("Single Room")]
        singleRoom,
        [Description("Double Room")]
        doubleRoom,
        [Description("Family Room")]
        familyRoom
    }
    public class HotelBooking : Booking
    {
        public Hotel hotel { get; set; }
        public int hotelID { get; set; }
        public RoomTypes roomType { get; set; }
        public string roomTypeString()
        {
            return "yes";
        }
    }
}
