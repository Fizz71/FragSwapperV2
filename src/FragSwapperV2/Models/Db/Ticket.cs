using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FragSwapperV2.Models.Db
{
    public enum PremiumTicketType
    {
        User = 1,
        Host = 2,
        Event = 3,
        Ad = 4,
    }

    public class Ticket
    {
        public int ID { get; set; }

        [MaxLength(20), Required]
        public string TicektNumber { get; set; }

        [Required]
        public PremiumTicketType Type { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        public Host Host { get; set; }

        public Event Event { get; set; }

        public Advertisement Advertisement { get; set; }

        [Required]
        public DateTime RequestedSDateTimed { get; set; }

        public DateTime? ReceivedSDateTimed { get; set; }

        [MaxLength(20)]
        public string PayPal_txn_id { get; set; }

        public double? PayPal_payment_gross { get; set; }

        public string PayPal_IPN_Repsonse { get; set; }

        // Null if auto-applied.
        public ApplicationUser AppliedUser { get; set; }

        public DateTime? AppliedSDateTimed { get; set; }


    }
}
