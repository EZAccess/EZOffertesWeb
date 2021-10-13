using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class RelationAddress
    {
        public int RelationAddressId { get; set; }
        [Required]
        public int RelationId { get; set; }
        [Required]
        [MaxLength(255)]
        public string AddressLine1 { get; set; }
        [MaxLength(255)]
        public string AddressLine2 { get; set; }
        [MaxLength(50)]
        public string PostalCode { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string AddressType { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
