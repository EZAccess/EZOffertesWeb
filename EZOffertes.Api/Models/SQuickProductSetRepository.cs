using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SQuickProductSetRepository : IQuickProductSetRepository
    {
        private readonly AppDbContext appDbContext;

        public SQuickProductSetRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<QuickProductSet> AddQuickProductSet(QuickProductSet quickProductSet)
        {
            var result = await appDbContext.QuickProductSets.AddAsync(quickProductSet);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QuickProductSet> DeleteQuickProductSet(int quickProductSetId)
        {
            var result = await appDbContext.QuickProductSets.FirstOrDefaultAsync(e => e.QuickProductSetId == quickProductSetId);
            if (result != null)
            {
                appDbContext.QuickProductSets.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<QuickProductSet> GetQuickProductSet(int quickProductSetId)
        {
            return await appDbContext.QuickProductSets
                .FirstOrDefaultAsync(e => e.QuickProductSetId == quickProductSetId);
        }

        public async Task<IEnumerable<QuickProductSet>> GetQuickProductSets()
        {
            return await appDbContext.QuickProductSets.ToListAsync();
        }

        public async Task<IEnumerable<QuickProductSet>> Search(string productDescription)
        {
            IQueryable<QuickProductSet> query = appDbContext.QuickProductSets;
            if (!string.IsNullOrEmpty(productDescription))
            {
                query = query.Where(e => e.ProductDescription.Contains(productDescription));
            }
            return await query.ToListAsync();
        }

        public async Task<QuickProductSet> UpdateQuickProductSet(QuickProductSet quickProductSet)
        {
            var result = await appDbContext.QuickProductSets.FirstOrDefaultAsync(e => e.QuickProductSetId == quickProductSet.QuickProductSetId);
            if (result != null)
            {
                result.QuickCode = quickProductSet.QuickCode;
                result.ProductDescription = quickProductSet.ProductDescription;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
