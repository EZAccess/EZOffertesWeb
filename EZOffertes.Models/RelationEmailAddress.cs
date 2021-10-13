using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class RelationEmailAddress
    {
        public int RelationEmailAddressId { get; set; }
        [Required]
        public int RelationId { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(255)]
        public string EmailAddress { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
