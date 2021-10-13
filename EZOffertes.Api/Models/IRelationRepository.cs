using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IRelationRepository
    {
        Task<IEnumerable<Relation>> Search(string name);
        Task<IEnumerable<Relation>> GetRelations();
        Task<Relation> GetRelation(int relationId);
        Task<Relation> AddRelation(Relation relation);
        Task<Relation> UpdateRelation(Relation relation);
        Task<Relation> DeleteRelation(int relationId);
    }
}
