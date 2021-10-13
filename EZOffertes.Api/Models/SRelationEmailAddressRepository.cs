using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SRelationEmailAddressRepository : IRelationEmailAddressRepository
    {
        private readonly AppDbContext appDbContext;

        public SRelationEmailAddressRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<RelationEmailAddress> AddRelationEmailAddress(RelationEmailAddress relationEmailAddress)
        {
            var result = await appDbContext.RelationEmailAddresses.AddAsync(relationEmailAddress);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RelationEmailAddress> DeleteRelationEmailAddress(int relationEmailAddressId)
        {
            var result = await appDbContext.RelationEmailAddresses.FirstOrDefaultAsync(e => e.RelationEmailAddressId == relationEmailAddressId);
            if (result != null)
            {
                appDbContext.RelationEmailAddresses.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<RelationEmailAddress> GetRelationEmailAddress(int relationEmailAddressId)
        {
            return await appDbContext.RelationEmailAddresses
                .FirstOrDefaultAsync(e => e.RelationEmailAddressId == relationEmailAddressId);
        }

        public async Task<IEnumerable<RelationEmailAddress>> GetRelationEmailAddresses()
        {
            return await appDbContext.RelationEmailAddresses.ToListAsync();
        }

        public async Task<IEnumerable<RelationEmailAddress>> Search(string emailAddress)
        {
            IQueryable<RelationEmailAddress> query = appDbContext.RelationEmailAddresses;
            if (!string.IsNullOrEmpty(emailAddress))
            {
                query = query.Where(e => e.EmailAddress == emailAddress);
            }
            return await query.ToListAsync();
        }

        public async Task<RelationEmailAddress> UpdateRelationEmailAddress(RelationEmailAddress relationEmailAddress)
        {
            var result = await appDbContext.RelationEmailAddresses.FirstOrDefaultAsync(e => e.RelationEmailAddressId == relationEmailAddress.RelationEmailAddressId);
            if (result != null)
            {
                if (result.RelationId != relationEmailAddress.RelationId)
                {
                    return null;
                }
                result.EmailAddress = relationEmailAddress.EmailAddress;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
