using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int? InvoiceId { get; set; }
        [Required]
        public PaymentType PaymentType { get; set; }
        [Required]
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int? EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
