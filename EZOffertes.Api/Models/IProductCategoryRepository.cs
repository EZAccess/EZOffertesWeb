using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetProductCategories();
        Task<ProductCategory> GetProductCategory(int productCategoryId);
        Task<ProductCategory> AddProductCategory(ProductCategory productCategory);
        Task<ProductCategory> UpdateProductCategory(ProductCategory productCategory);
        Task<ProductCategory> DeleteProductCategory(int productCategoryId);
    }
}
