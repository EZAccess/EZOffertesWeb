using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EZOffertes.Models
{
    [Index(nameof(Unit), IsUnique = true)]
    public class UnitOfMeasure
    {
        public int UnitOfMeasureId { get; set; }
        [MaxLength(50)]
        public string Unit { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
