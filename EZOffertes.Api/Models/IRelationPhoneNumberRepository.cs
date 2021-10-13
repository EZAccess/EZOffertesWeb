using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IRelationPhoneNumberRepository
    {
        Task<IEnumerable<RelationPhoneNumber>> Search(string phoneNumber);
        Task<IEnumerable<RelationPhoneNumber>> GetRelationPhoneNumbers();
        Task<RelationPhoneNumber> GetRelationPhoneNumber(int relationPhoneNumberId);
        Task<RelationPhoneNumber> AddRelationPhoneNumber(RelationPhoneNumber relationPhoneNumber);
        Task<RelationPhoneNumber> UpdateRelationPhoneNumber(RelationPhoneNumber relationPhoneNumber);
        Task<RelationPhoneNumber> DeleteRelationPhoneNumber(int relationPhoneNumberId);
    }
}
