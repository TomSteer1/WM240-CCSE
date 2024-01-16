using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class Booking
    {
        [Key]
        public string id { get; set; } = Guid.NewGuid().ToString();
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string? forename { get; set; }
        public string? surname { get; set; }
        public string? userID { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal totalCost { get; set; }
        public bool depositPaid { get; set; } = false;
        [Column(TypeName = "decimal(18,2)")]
        public Decimal totalPaid { get; set; }
        public Payment? payment { get; set; }

    }
}
