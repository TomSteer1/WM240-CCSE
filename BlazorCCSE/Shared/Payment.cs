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
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string? bookingID { get; set; }
        public string cardNumber { get; set; } = "";
        public int expiryMonth { get; set; } = 1;
        public int expiryYear { get; set; } = 2024;
        public string cvv { get; set; } = "";
        public string name { get; set; } = "John Smith";
        public decimal amount { get; set; }

        public IEnumerable<PaymentItem> items {  get; set; } = new PaymentItem[0];

        public bool Validate()
        {
            if(cardNumber == null || cvv == null || name == null || expiryMonth == null || expiryYear == null)
            {
                return false;
            }
            if(cardNumber.Length != 16 || cvv.Length != 3 || expiryMonth < 1 || expiryMonth > 12 || expiryYear < DateTime.Now.Year || name.Length <= 0 || amount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Process()
        {
            // TODO: Process payment
            return true;
        }

        public string GetReceipt()
        {
            string receipt = "";
            receipt += "Pacific Tours\n\n";
            foreach(PaymentItem item in items)
            {
                receipt += item.Name + " x " + item.quantity + " - £" + (item.cost * item.quantity) + "\n";
            }
            receipt += "\nTotal : £" + amount;
            return receipt;
        }
    }
}
