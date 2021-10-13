using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    [Index(nameof(QuickProductSetId), nameof(QuickOption), IsUnique = true)]
    public class QuickProductSetItem
    {
        public int QuickProductSetItemId { get; set; }
        [Required]
        public int QuickProductSetId { get; set; }
        [MaxLength(50)]
        public string QuickOption { get; set; }
        [Required]
        public int Sequence { get; set; }
        [MaxLength(255)]
        public string OptionDescription { get; set; }
        [Required]
        public bool IsDefault { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
