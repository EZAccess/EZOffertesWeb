using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiShippingMethodService : HttpService, IShippingMethodService
    {
        public ApiShippingMethodService(HttpClient httpClient) : base(httpClient) { }


        public async Task<ShippingMethod> CreateShippingMethod(ShippingMethod newShippingMethod, ErrorInfo err) =>
            (await HttpPost<ShippingMethod>($"api/shippingmethods", newShippingMethod, err));

        public async Task<bool> DeleteShippingMethod(int id, ErrorInfo err) =>
            (await HttpDelete($"api/shippingmethods/{id}", err));

        public async Task<ShippingMethod> GetShippingMethod(int id, ErrorInfo err) =>
            (await HttpGet<ShippingMethod>($"api/shippingmethods/{id}", err));

        public async Task<IEnumerable<ShippingMethod>> GetShippingMethods(ErrorInfo err) =>
            (await HttpGet<IEnumerable<ShippingMethod>>("api/shippingmethods", err));

        public async Task<ShippingMethod> UpdateShippingMethod(ShippingMethod updatedShippingMethod, ErrorInfo err) =>
            (await HttpPut<ShippingMethod>("api/shippingmethods", updatedShippingMethod, err));

    }
}
