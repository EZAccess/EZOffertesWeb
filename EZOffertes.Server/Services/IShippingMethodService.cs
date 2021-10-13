using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IShippingMethodService
    {
        Task<IEnumerable<ShippingMethod>> GetShippingMethods(ErrorInfo err);
        Task<ShippingMethod> GetShippingMethod(int id, ErrorInfo err);
        Task<ShippingMethod> UpdateShippingMethod(ShippingMethod updatedShippingMethod, ErrorInfo err);
        Task<ShippingMethod> CreateShippingMethod(ShippingMethod newShippingMethod, ErrorInfo err);
        Task<bool> DeleteShippingMethod(int id, ErrorInfo err);
    }
}
