using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    interface IQuickProductSetItemRepository
    {
        Task<IEnumerable<QuickProductSetItem>> Search(string optionDescription);
        Task<IEnumerable<QuickProductSetItem>> GetQuickProductSetItems();
        Task<QuickProductSetItem> GetQuickProductSetItem(int quickProductSetId);
        Task<QuickProductSetItem> AddQuickProductSetItem(QuickProductSetItem quickProductSetItem);
        Task<QuickProductSetItem> UpdateQuickProductSetItem(QuickProductSetItem quickProductSetItem);
        Task<QuickProductSetItem> DeleteQuickProductSetItem(int quickProductSetId);
    }
}
