using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiQuickProductSetService : HttpService, IQuickProductSetService
    {
        public ApiQuickProductSetService(HttpClient httpClient) : base(httpClient) { }


        public async Task<QuickProductSet> CreateQuickProductSet(QuickProductSet newQuickProductSet, ErrorInfo err) =>
            (await HttpPost<QuickProductSet>($"api/quickproductsets", newQuickProductSet, err));

        public async Task<bool> DeleteQuickProductSet(int id, ErrorInfo err) =>
            (await HttpDelete($"api/quickproductsets/{id}", err));

        public async Task<QuickProductSet> GetQuickProductSet(int id, ErrorInfo err) =>
            (await HttpGet<QuickProductSet>($"api/quickproductsets/{id}", err));

        public async Task<IEnumerable<QuickProductSet>> GetQuickProductSets(ErrorInfo err) =>
            (await HttpGet<IEnumerable<QuickProductSet>>("api/quickproductsets", err));

        public async Task<QuickProductSet> UpdateQuickProductSet(QuickProductSet updatedQuickProductSet, ErrorInfo err) =>
            (await HttpPut<QuickProductSet>("api/quickproductsets", updatedQuickProductSet, err));
    }
}
