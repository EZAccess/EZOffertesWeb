using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        [Required]
        public int InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        [Required]
        public InvoiceStatus InvoiceStatus { get; set; }
        public DateTime? DateReminder { get; set; }
        public DateTime? DateWarning { get; set; }
        public double VATTariff { get; set; }
        public double DiscountPerc { get; set; }
        public double Calc_AmountGrossIncl { get; set; }
        public double Calc_AmountGrossExcl { get; set; }
        public double Calc_AmountDiscountIncl { get; set; }
        public double Calc_AmountDiscountExcl { get; set; }
        public double Calc_AmountVAT { get; set; }
        public double Calc_AmountIncl { get; set; }
        public double Calc_AmountExcl { get; set; }
        public List<Payment> Payments { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
