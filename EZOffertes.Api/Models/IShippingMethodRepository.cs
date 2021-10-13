using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IShippingMethodRepository
    {
        Task<IEnumerable<ShippingMethod>> GetShippingMethods();
        Task<ShippingMethod> GetShippingMethod(int shippingMethodId);
        Task<ShippingMethod> AddShippingMethod(ShippingMethod shippingMethod);
        Task<ShippingMethod> UpdateShippingMethod(ShippingMethod shippingMethod);
        Task<ShippingMethod> DeleteShippingMethod(int shippingMethodId);
    }
}
