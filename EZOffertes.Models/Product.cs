using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ArticleCode { get; set; }
        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [MaxLength(50)]
        public string Unit { get; set; }
        [MaxLength(255)]
        public string TextOffer { get; set; }
        [MaxLength(255)]
        public string TextOrder { get; set; }
        public int? SupplierId { get; set; }
        [MaxLength(255)]
        public string SupplierArticleNumber { get; set; }
        [MaxLength(255)]
        public string SupplierProductDescription{ get; set; }
        public List<ProductProperty> ProductProperties { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
