using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IQuickProductSetService
    {
        Task<IEnumerable<QuickProductSet>> GetQuickProductSets(ErrorInfo err);
        Task<QuickProductSet> GetQuickProductSet(int id, ErrorInfo err);
        Task<QuickProductSet> UpdateQuickProductSet(QuickProductSet updatedQuickProductSet, ErrorInfo err);
        Task<QuickProductSet> CreateQuickProductSet(QuickProductSet newQuickProductSet, ErrorInfo err);
        Task<bool> DeleteQuickProductSet(int id, ErrorInfo err);
    }
}
