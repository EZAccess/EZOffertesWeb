using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts(ErrorInfo err);
        Task<Product> GetProduct(int id, ErrorInfo err);
        Task<Product> UpdateProduct(Product updatedProduct, ErrorInfo err);
        Task<Product> CreateProduct(Product newProduct, ErrorInfo err);
        Task<bool> DeleteProduct(int id, ErrorInfo err);
    }
}
