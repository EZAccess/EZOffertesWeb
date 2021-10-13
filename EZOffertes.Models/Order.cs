using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        //[ForeignKey("CustomerId")]
        //public Relation Relation { get; set; }
        [Required]
        public int? EmployeeId { get; set; }
        //public Employee Employee { get; set; }
        [Required]
        public OrderStatus OrderStatus { get; set; }
        public DateTime OfferDate { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool IsInvoiced { get; set; }
        [MaxLength(255)]
        public string CustomerReference { get; set; }
        public int? ShippingMethodId { get; set; }
        //[ForeignKey("ShippingMethodId")]
        //public ShippingMethod ShippingMethod { get; set; }
        public DateTime? ShippingDate { get; set; }
        [MaxLength(255)]
        public string ShippingName { get; set; }
        [MaxLength(255)]
        public string ShippingAddressLine1 { get; set; }
        [MaxLength(255)]
        public string ShippingAddressLine2 { get; set; }
        [MaxLength(50)]
        public string ShippingPostalCode { get; set; }
        [MaxLength(50)]
        public string ShippingCity { get; set; }
        [MaxLength(50)]
        public string ShippingState { get; set; }
        [MaxLength(50)]
        public string ShippingCountry { get; set; }
        [MaxLength(50)]
        public string ShippingPhoneNumber { get; set; }
        [MaxLength(255)]
        public string ShippingComments { get; set; }
        public double VATTariff { get; set; }
        public double DiscountPerc { get; set; }
        public int? PackingList { get; set; }
        public DateTime? PackingDate { get; set; }
        public string Notes { get; set; }
        public double Calc_SumAmount { get; set; }
        public double Calc_TotalOffer { get; set; }
        public double Calc_TotalOrder { get; set; }
        public double Calc_TotalPaid { get; set; }
        public double Calc_TotalInvoiced { get; set; }
        public RecordStatus RecordStatus { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
