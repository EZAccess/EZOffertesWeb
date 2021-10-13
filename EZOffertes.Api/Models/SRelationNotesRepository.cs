using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SRelationNoteRepository : IRelationNoteRepository
    {
        private readonly AppDbContext appDbContext;

        public SRelationNoteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<RelationNote> AddRelationNote(RelationNote relationNote)
        {
            var result = await appDbContext.RelationNotes.AddAsync(relationNote);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RelationNote> DeleteRelationNote(int relationNoteId)
        {
            var result = await appDbContext.RelationNotes.FirstOrDefaultAsync(e => e.RelationNoteId == relationNoteId);
            if (result != null)
            {
                appDbContext.RelationNotes.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<RelationNote> GetRelationNote(int relationNoteId)
        {
            return await appDbContext.RelationNotes
                .FirstOrDefaultAsync(e => e.RelationNoteId == relationNoteId);
        }

        public async Task<IEnumerable<RelationNote>> GetRelationNotes()
        {
            return await appDbContext.RelationNotes.ToListAsync();
        }

        public async Task<RelationNote> UpdateRelationNote(RelationNote relationNote)
        {
            var result = await appDbContext.RelationNotes.FirstOrDefaultAsync(e => e.RelationNoteId == relationNote.RelationNoteId);
            if (result != null)
            {
                if (result.RelationId != relationNote.RelationId)
                {
                    return null;
                }
                result.Text = relationNote.Text;
                result.NoteDate = relationNote.NoteDate;
                result.EmployeeId = relationNote.EmployeeId;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
