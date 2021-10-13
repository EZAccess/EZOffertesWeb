using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    [Index(nameof(ProductCategoryName), IsUnique = true)]
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ProductCategoryName { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
