using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IRelationService
    {
        Task<IEnumerable<Relation>> Search(string name, ErrorInfo err);
        Task<IEnumerable<Relation>> GetRelations(ErrorInfo err);
        Task<Relation> GetRelation(int id, ErrorInfo err);
        Task<Relation> UpdateRelation(Relation updatedRelation, ErrorInfo err);
        Task<Relation> CreateRelation(Relation newRelation, ErrorInfo err);
        Task<bool> DeleteRelation(int id, ErrorInfo err);
    }
}
