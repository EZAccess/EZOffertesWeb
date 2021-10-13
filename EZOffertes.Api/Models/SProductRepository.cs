using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SProductRepository : IProductRepository
    {
        private readonly AppDbContext appDbContext;

        public SProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await appDbContext.Products.AddAsync(product);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(e => e.ProductId == productId);
            if (result != null)
            {
                appDbContext.Products.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Product> GetProduct(int productId)
        {
            return await appDbContext.Products
//                .Include(o => o.ProductProperties)
                .FirstOrDefaultAsync(e => e.ProductId == productId);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await appDbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> Search(string productName)
        {
            IQueryable<Product> query = appDbContext.Products;
            if (!string.IsNullOrEmpty(productName ))
            {
                query = query.Where(e => e.ProductName.Contains(productName));
            }
            return await query.ToListAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var result = await appDbContext.Products.FirstOrDefaultAsync(e => e.ProductId == product.ProductId);
            if (result != null)
            {
                result.ArticleCode = product.ArticleCode;
                result.ProductName = product.ProductName;
                result.Description = product.Description;
                result.Price = product.Price;
                result.Unit = product.Unit;
                result.TextOffer = product.TextOffer;
                result.TextOrder = product.TextOrder;
                result.SupplierId = product.SupplierId;
                result.SupplierArticleNumber = product.SupplierArticleNumber;
                result.SupplierProductDescription = product.SupplierProductDescription;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
