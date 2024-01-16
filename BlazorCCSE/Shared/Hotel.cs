using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class Hotel
    {
        public string name { get; set; }
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        public Decimal singlePrice { get; set; }
        public Decimal doublePrice { get; set; }
        public Decimal familyPrice { get; set; }
        public int singleRooms { get; set; } = 20;
        public int doubleRooms { get; set; } = 20;
        public int familyRooms { get; set; } = 20;

        public Decimal GetPrice(RoomTypes room)
        {
            switch (room)
            {
                case RoomTypes.singleRoom:
                    return singlePrice;
                case RoomTypes.doubleRoom:
                    return doublePrice;
                case RoomTypes.familyRoom:
                    return familyPrice;
                default:
                    return singlePrice;
            }
        }
        public int GetRooms(RoomTypes room)
        {
            switch (room)
            {
                case RoomTypes.singleRoom:
                    return singleRooms;
                case RoomTypes.doubleRoom:
                    return doubleRooms;
                case RoomTypes.familyRoom:
                    return familyRooms;
                default:
                    return singleRooms;
            }
        }
        public string GetRoomType(RoomTypes room)
        {
            switch (room)
            {
                case RoomTypes.singleRoom:
                    return "Single Room";
                case RoomTypes.doubleRoom:
                    return "Double Room";
                case RoomTypes.familyRoom:
                    return "Family Room";
                default:
                    return "Single Room";
            }
        }
    }
}
