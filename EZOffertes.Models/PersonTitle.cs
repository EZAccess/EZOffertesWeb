using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class PersonTitle
    {
        public int PersonTitleId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
