using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IRelationAddressRepository
    {
        Task<IEnumerable<RelationAddress>> Search(string address);
        Task<IEnumerable<RelationAddress>> GetRelationAddresses();
        Task<RelationAddress> GetRelationAddress(int relationAddressId);
        Task<RelationAddress> AddRelationAddress(RelationAddress relationAddress);
        Task<RelationAddress> UpdateRelationAddress(RelationAddress relationAddress);
        Task<RelationAddress> DeleteRelationAddress(int relationAddressId);
    }
}
