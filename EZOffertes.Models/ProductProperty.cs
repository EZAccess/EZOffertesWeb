using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class ProductProperty
    {
        public int ProductPropertyId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PropertyName { get; set; }
        [MaxLength(255)]
        public string PropertyValue { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
