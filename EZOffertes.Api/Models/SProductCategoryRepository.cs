using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public SProductCategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<ProductCategory> AddProductCategory(ProductCategory productCategory)
        {
            var result = await appDbContext.ProductCategories.AddAsync(productCategory);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductCategory> DeleteProductCategory(int productCategoryId)
        {
            var result = await appDbContext.ProductCategories.FirstOrDefaultAsync(e => e.ProductCategoryId == productCategoryId);
            if (result != null)
            {
                appDbContext.ProductCategories.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<ProductCategory> GetProductCategory(int productCategoryId)
        {
            return await appDbContext.ProductCategories
                .FirstOrDefaultAsync(e => e.ProductCategoryId == productCategoryId);
        }

        public async Task<IEnumerable<ProductCategory>> GetProductCategories()
        {
            return await appDbContext.ProductCategories.ToListAsync();
        }

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory)
        {
            var result = await appDbContext.ProductCategories.FirstOrDefaultAsync(e => e.ProductCategoryId == productCategory.ProductCategoryId);
            if (result != null)
            {
                result.ProductCategoryName = productCategory.ProductCategoryName;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
