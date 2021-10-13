using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetProductCategories(ErrorInfo err);
        Task<ProductCategory> GetProductCategory(int id, ErrorInfo err);
        Task<ProductCategory> UpdateProductCategory(ProductCategory updatedProductCategory, ErrorInfo err);
        Task<ProductCategory> CreateProductCategory(ProductCategory newProductCategory, ErrorInfo err);
        Task<bool> DeleteProductCategory(int id, ErrorInfo err);
    }
}
