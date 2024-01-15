using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCCSE.Shared
{
    public class Payment
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public Guid bookingID { get; set; }
        public int cardNumber { get; set; } = 0;
        public int expiryMonth { get; set; } = 1;
        public int expiryYear { get; set; } = 2024;
        public int cvv { get; set; } = 123;
        public string name { get; set; } = "John Smith";
        public decimal amount { get; set; }

    }
}
