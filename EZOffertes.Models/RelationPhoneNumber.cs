using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class RelationPhoneNumber
    {
        public int RelationPhoneNumberId { get; set; }
        [Required]
        public int RelationId { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
        [MaxLength(50)]
        public string PhoneNumberType { get; set; }
        public bool IsFirstPhoneNumber { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
