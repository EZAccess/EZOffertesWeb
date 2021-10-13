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
    [Index(nameof(QuickCode), IsUnique = true)]
    public class QuickProductSet
    {
        public int QuickProductSetId { get; set; }
        [MaxLength(50)]
        public string QuickCode { get; set; }
        [MaxLength(255)]
        public string ProductDescription { get; set; }
        public List<QuickProductSetItem> Items { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
