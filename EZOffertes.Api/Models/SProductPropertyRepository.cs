using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SProductPropertyRepository : IProductPropertyRepository
    {
        private readonly AppDbContext appDbContext;

        public SProductPropertyRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ProductProperty> AddProductProperty(ProductProperty productProperty)
        {
            var result = await appDbContext.ProductProperties.AddAsync(productProperty);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductProperty> DeleteProductProperty(int productPropertyId)
        {
            var result = await appDbContext.ProductProperties.FirstOrDefaultAsync(e => e.ProductPropertyId == productPropertyId);
            if (result != null)
            {
                appDbContext.ProductProperties.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ProductProperty> GetProductProperty(int productPropertyId)
        {
            return await appDbContext.ProductProperties
                .FirstOrDefaultAsync(e => e.ProductPropertyId == productPropertyId);
        }

        public async Task<IEnumerable<ProductProperty>> GetProductProperties()
        {
            return await appDbContext.ProductProperties.ToListAsync();
        }

        public async Task<IEnumerable<ProductProperty>> GetProductPropertiesByProduct(int productId)
        {
            IQueryable<ProductProperty> query = appDbContext.ProductProperties;
            query = query.Where(e => e.ProductId == productId);
            return await query.ToListAsync();
        }

        public async Task<ProductProperty> UpdateProductProperty(ProductProperty productProperty)
        {
            var result = await appDbContext.ProductProperties.FirstOrDefaultAsync(e => e.ProductPropertyId == productProperty.ProductPropertyId);
            if (result != null)
            {
                if (result.ProductId != productProperty.ProductId)
                {
                    return null;
                }
                result.PropertyName = productProperty.PropertyName;
                result.PropertyValue = productProperty.PropertyValue;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
