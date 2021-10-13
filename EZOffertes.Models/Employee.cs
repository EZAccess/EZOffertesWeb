using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class Employee 
    {
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FamilyName { get; set; }
        [MaxLength(50)]
        public string FamilyNamePrefix { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Initials { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public string EmailAddress { get; set; }
        [MaxLength(50)]
        public string FunctionName { get; set; }
        public bool Active { get; set; }
        public int Clearance { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
