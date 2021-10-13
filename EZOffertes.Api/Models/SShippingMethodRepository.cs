using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SShippingMethodRepository : IShippingMethodRepository
    {
        private readonly AppDbContext appDbContext;

        public SShippingMethodRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ShippingMethod> AddShippingMethod(ShippingMethod shippingMethod)
        {
            var result = await appDbContext.ShippingMethods.AddAsync(shippingMethod);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ShippingMethod> DeleteShippingMethod(int shippingMethodId)
        {
            var result = await appDbContext.ShippingMethods.FirstOrDefaultAsync(e => e.ShippingMethodId == shippingMethodId);
            if (result != null)
            {
                appDbContext.ShippingMethods.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ShippingMethod> GetShippingMethod(int shippingMethodId)
        {
            return await appDbContext.ShippingMethods
                .FirstOrDefaultAsync(e => e.ShippingMethodId == shippingMethodId);
        }

        public async Task<IEnumerable<ShippingMethod>> GetShippingMethods()
        {
            return await appDbContext.ShippingMethods.ToListAsync();
        }

        public async Task<ShippingMethod> UpdateShippingMethod(ShippingMethod shippingMethod)
        {
            var result = await appDbContext.ShippingMethods.FirstOrDefaultAsync(e => e.ShippingMethodId == shippingMethod.ShippingMethodId);
            if (result != null)
            {
                result.ShippingMethodName = shippingMethod.ShippingMethodName;
                result.Description = shippingMethod.Description;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
