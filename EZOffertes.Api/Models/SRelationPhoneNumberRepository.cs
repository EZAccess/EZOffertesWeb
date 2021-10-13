using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SRelationPhoneNumberRepository : IRelationPhoneNumberRepository
    {
        private readonly AppDbContext appDbContext;

        public SRelationPhoneNumberRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<RelationPhoneNumber> AddRelationPhoneNumber(RelationPhoneNumber relationPhoneNumber)
        {
            var result = await appDbContext.RelationPhoneNumbers.AddAsync(relationPhoneNumber);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<RelationPhoneNumber> DeleteRelationPhoneNumber(int relationPhoneNumberId)
        {
            var result = await appDbContext.RelationPhoneNumbers.FirstOrDefaultAsync(e => e.RelationPhoneNumberId == relationPhoneNumberId);
            if (result != null)
            {
                appDbContext.RelationPhoneNumbers.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<RelationPhoneNumber> GetRelationPhoneNumber(int relationPhoneNumberId)
        {
            return await appDbContext.RelationPhoneNumbers
                .FirstOrDefaultAsync(e => e.RelationPhoneNumberId == relationPhoneNumberId);
        }

        public async Task<IEnumerable<RelationPhoneNumber>> GetRelationPhoneNumbers()
        {
            return await appDbContext.RelationPhoneNumbers.ToListAsync();
        }

        public async Task<IEnumerable<RelationPhoneNumber>> Search(string phonenumber)
        {
            IQueryable<RelationPhoneNumber> query = appDbContext.RelationPhoneNumbers;
            if (!string.IsNullOrEmpty(phonenumber))
            {
                query = query.Where(e => e.PhoneNumber == phonenumber);
            }
            return await query.ToListAsync();
        }

        public async Task<RelationPhoneNumber> UpdateRelationPhoneNumber(RelationPhoneNumber relationPhoneNumber)
        {
            var result = await appDbContext.RelationPhoneNumbers.FirstOrDefaultAsync(e => e.RelationPhoneNumberId == relationPhoneNumber.RelationPhoneNumberId);
            if (result != null)
            {
                if (result.RelationId != relationPhoneNumber.RelationId)
                {
                    return null;
                }
                result.PhoneNumber = relationPhoneNumber.PhoneNumber;
                result.PhoneNumberType = relationPhoneNumber.PhoneNumberType;
                result.IsFirstPhoneNumber = relationPhoneNumber.IsFirstPhoneNumber;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
