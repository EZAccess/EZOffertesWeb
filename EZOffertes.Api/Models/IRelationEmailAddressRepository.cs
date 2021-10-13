using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IRelationEmailAddressRepository
    {
        Task<IEnumerable<RelationEmailAddress>> Search(string emailAddress);
        Task<IEnumerable<RelationEmailAddress>> GetRelationEmailAddresses();
        Task<RelationEmailAddress> GetRelationEmailAddress(int relationEmailAddressId);
        Task<RelationEmailAddress> AddRelationEmailAddress(RelationEmailAddress relationEmailAddress);
        Task<RelationEmailAddress> UpdateRelationEmailAddress(RelationEmailAddress relationEmailAddress);
        Task<RelationEmailAddress> DeleteRelationEmailAddress(int relationEmailAddressId);
    }
}
