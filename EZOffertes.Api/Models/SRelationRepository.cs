using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SRelationRepository : IRelationRepository
    {
        private readonly AppDbContext appDbContext;

        public SRelationRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Relation> AddRelation(Relation relation)
        {
            var result = await appDbContext.Relations.AddAsync(relation);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Relation> DeleteRelation(int relationId)
        {
            var result = await appDbContext.Relations.FirstOrDefaultAsync(e => e.RelationId == relationId);
            if (result != null)
            {
                appDbContext.Relations.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Relation> GetRelation(int relationId)
        {
            return await appDbContext.Relations
                //.Include(r => r.Addresses)
                //.Include(r => r.PhoneNumbers)
                //.Include(r => r.Notes)
                .FirstOrDefaultAsync(e => e.RelationId == relationId);
        }

        public async Task<IEnumerable<Relation>> GetRelations()
        {
            return await appDbContext.Relations.ToListAsync();
        }

        public async Task<IEnumerable<Relation>> Search(string name)
        {
            IQueryable<Relation> query = appDbContext.Relations;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.CompanyName.Contains(name) || e.FamilyName.Contains(name) || e.FirstName.Contains(name));
            }
            return await query.ToListAsync();
        }

        public async Task<Relation> UpdateRelation(Relation relation)
        {
            var result = await appDbContext.Relations.FirstOrDefaultAsync(e => e.RelationId == relation.RelationId);
            if (result != null)
            {
                result.IsCustomer = relation.IsCustomer;
                result.IsSupplier = relation.IsSupplier;
                result.IsConsumer = relation.IsConsumer;
                result.RelationName = relation.RelationName;
                result.CompanyName = relation.CompanyName;
                result.CompanyNamePrefix = relation.CompanyNamePrefix;
                result.FamilyName = relation.FamilyName;
                result.FamilyNamePrefix = relation.FamilyNamePrefix;
                result.FirstName = relation.FirstName;
                result.Title = relation.Title;
                result.OrderMethod = relation.OrderMethod;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
