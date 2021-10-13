using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class ShippingMethod
    {
        public int ShippingMethodId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShippingMethodName { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
