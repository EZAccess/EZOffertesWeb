using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class RelationNote
    {
        public int RelationNoteId { get; set; }
        [Required]
        public int RelationId { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime NoteDate { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
