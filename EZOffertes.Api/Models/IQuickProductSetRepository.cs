using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IQuickProductSetRepository
    {
        Task<IEnumerable<QuickProductSet>> Search(string productDescription);
        Task<IEnumerable<QuickProductSet>> GetQuickProductSets();
        Task<QuickProductSet> GetQuickProductSet(int quickProductSetId);
        Task<QuickProductSet> AddQuickProductSet(QuickProductSet quickProductSet);
        Task<QuickProductSet> UpdateQuickProductSet(QuickProductSet quickProductSet);
        Task<QuickProductSet> DeleteQuickProductSet(int quickProductSetId);
    }
}
