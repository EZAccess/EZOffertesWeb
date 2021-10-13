using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IRelationNoteRepository
    {
        Task<IEnumerable<RelationNote>> GetRelationNotes();
        Task<RelationNote> GetRelationNote(int relationNoteId);
        Task<RelationNote> AddRelationNote(RelationNote relationNote);
        Task<RelationNote> UpdateRelationNote(RelationNote relationNote);
        Task<RelationNote> DeleteRelationNote(int relationNoteId);
    }
}
