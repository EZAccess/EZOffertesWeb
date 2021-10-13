using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Sequence { get; set; } = 0;
        [MaxLength(50)]
        public string ProjectName { get; set; }
        [MaxLength(50)]
        public string ProductCategory { get; set; }
        public int? ProductId { get; set; }
        //public Product Product { get; set; }
        [MaxLength(255)]
        public string TextOffer { get; set; }
        [MaxLength(255)]
        public string TextOrder { get; set; }
        [Required]
        public double Quantity { get; set; } = 1;
        [MaxLength(50)]
        public string Unit { get; set; }
        [Required]
        public double Price { get; set; } = 0;
        public double Calc_DetailAmount { get; set; } = 0;
        public int? SupplierId { get; set; }
        public SupplierStatus SupplierStatus { get; set; } = 0;
        [MaxLength(255)]
        public string SupplierArticleNumber { get; set; }
        [MaxLength(255)]
        public string SupplierProductDescription { get; set; }
        [MaxLength(255)]
        public string SupplierComment { get; set; }
        public DateTime? SupplierOrderDate { get; set; }
        [MaxLength(255)]
        public string SupplierOrderReference { get; set; }
        public DateTime? SupplierConfirmDate { get; set; }
        public DateTime? SupplierDeliveryDate { get; set; }
        public ShippingStatus ShippingStatus { get; set; } = 0;
        public int? PackListId { get; set; }
        public int? ParentOrderDetailId { get; set; }
        public bool IsInternalComment { get; set; } = false;
        public bool ActionSelect { get; set; } = false;
        public int? InvoiceId { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }

    }
}
