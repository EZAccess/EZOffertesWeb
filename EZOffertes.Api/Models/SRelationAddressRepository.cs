using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SRelationAddressRepository : IRelationAddressRepository
    {
        private readonly AppDbContext appDbContext;

        public SRelationAddressRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<RelationAddress> AddRelationAddress(RelationAddress relationAddress)
        {
            var result = await appDbContext.RelationAddresses.AddAsync(relationAddress);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RelationAddress> DeleteRelationAddress(int relationAddressId)
        {
            var result = await appDbContext.RelationAddresses.FirstOrDefaultAsync(e => e.RelationAddressId == relationAddressId);
            if (result != null)
            {
                appDbContext.RelationAddresses.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<RelationAddress> GetRelationAddress(int relationAddressId)
        {
            return await appDbContext.RelationAddresses
                .FirstOrDefaultAsync(e => e.RelationAddressId == relationAddressId);
        }

        public async Task<IEnumerable<RelationAddress>> GetRelationAddresses()
        {
            return await appDbContext.RelationAddresses.ToListAsync();
        }

        public async Task<IEnumerable<RelationAddress>> Search(string address)
        {
            IQueryable<RelationAddress> query = appDbContext.RelationAddresses;
            if (!string.IsNullOrEmpty(address))
            {
                query = query.Where(e => e.AddressLine1.Contains(address) || e.AddressLine2.Contains(address));
            }
            return await query.ToListAsync();
        }

        public async Task<RelationAddress> UpdateRelationAddress(RelationAddress relationAddress)
        {
            var result = await appDbContext.RelationAddresses.FirstOrDefaultAsync(e => e.RelationAddressId == relationAddress.RelationAddressId);
            if (result != null)
            {
                if (result.RelationId != relationAddress.RelationId)
                {
                    return null;
                }
                result.AddressLine1 = relationAddress.AddressLine1;
                result.AddressLine2 = relationAddress.AddressLine2;
                result.PostalCode = relationAddress.PostalCode;
                result.City = relationAddress.City;
                result.State = relationAddress.State;
                result.Country = relationAddress.Country;
                result.AddressType = relationAddress.AddressType;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
