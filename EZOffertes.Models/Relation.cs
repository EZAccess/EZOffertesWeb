using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOffertes.Models
{
    public class Relation
    {
        public int RelationId { get; set; }
        [Required]
        public bool IsCustomer { get; set; }
        [Required]
        public bool IsSupplier { get; set; }
        [Required]
        public bool IsConsumer { get; set; }
        [Required]
        [MaxLength(510)]
        public string RelationName { get; set; }
        [MaxLength(255)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string CompanyNamePrefix { get; set; }
        [MaxLength(255)]
        public string FamilyName { get; set; }
        [MaxLength(50)]
        public string FamilyNamePrefix { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public List<RelationAddress> Addresses { get; set; }
        public List<RelationPhoneNumber> PhoneNumbers { get; set; }
        public int? FirstPhoneNumberId{ get; set; }
        //[ForeignKey("FirstPhoneNumberId")]
        //public RelationPhoneNumber FirstPhoneNumber { get; set; }
        public List<RelationEmailAddress> EmailAddresses { get; set; }
        public int? DefaultEmailAddressId { get; set; }
        //[ForeignKey("DefaultEmailAddressId")]
        //public RelationEmailAddress DefaultEmailAddress { get; set; }
        public int? InvoiceEmailAddressId { get; set; }
        //[ForeignKey("InvoiceEmailAddressId")]
        //public RelationEmailAddress InvoiceEmailAddress { get; set; }
        public int? OrderEmailAddressId { get; set; }
        //[ForeignKey("OrderEmailAddressId")]
        //public RelationEmailAddress OrderEmailAddress { get; set; }
        public OrderMethod OrderMethod { get; set; }
        public List<RelationNote> Notes { get; set; }
        public DateTime? TsCreated { get; set; }
        public DateTime? TsUpdated { get; set; }
    }
}
