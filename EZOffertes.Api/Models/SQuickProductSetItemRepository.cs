using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SQuickProductSetItemRepository : IQuickProductSetItemRepository
    {
        private readonly AppDbContext appDbContext;

        public SQuickProductSetItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<QuickProductSetItem> AddQuickProductSetItem(QuickProductSetItem quickProductSetItem)
        {
            var result = await appDbContext.QuickProductSetItems.AddAsync(quickProductSetItem);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QuickProductSetItem> DeleteQuickProductSetItem(int quickProductSetId)
        {
            var result = await appDbContext.QuickProductSetItems.FirstOrDefaultAsync(e => e.QuickProductSetId == quickProductSetId);
            if (result != null)
            {
                appDbContext.QuickProductSetItems.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<QuickProductSetItem> GetQuickProductSetItem(int quickProductSetId)
        {
            return await appDbContext.QuickProductSetItems
                .FirstOrDefaultAsync(e => e.QuickProductSetId == quickProductSetId);
        }

        public async Task<IEnumerable<QuickProductSetItem>> GetQuickProductSetItems()
        {
            return await appDbContext.QuickProductSetItems.ToListAsync();
        }

        public async Task<IEnumerable<QuickProductSetItem>> Search(string optionDescription)
        {
            IQueryable<QuickProductSetItem> query = appDbContext.QuickProductSetItems;
            if (!string.IsNullOrEmpty(optionDescription))
            {
                query = query.Where(e => e.OptionDescription.Contains(optionDescription));
            }
            return await query.ToListAsync();
        }

        public async Task<QuickProductSetItem> UpdateQuickProductSetItem(QuickProductSetItem quickProductSetItem)
        {
            var result = await appDbContext.QuickProductSetItems.FirstOrDefaultAsync(e => e.QuickProductSetItemId == quickProductSetItem.QuickProductSetItemId);
            if (result != null)
            {
                if (result.QuickProductSetId != quickProductSetItem.QuickProductSetId)
                {
                    return null;
                }
                result.QuickOption = quickProductSetItem.QuickOption;
                result.Sequence = quickProductSetItem.Sequence;
                result.OptionDescription = quickProductSetItem.OptionDescription;
                result.IsDefault = quickProductSetItem.IsDefault;
                result.ProductId = quickProductSetItem.ProductId;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
