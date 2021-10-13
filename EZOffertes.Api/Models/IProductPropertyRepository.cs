using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IProductPropertyRepository
    {
        Task<IEnumerable<ProductProperty>> GetProductPropertiesByProduct(int productId);
        Task<IEnumerable<ProductProperty>> GetProductProperties();
        Task<ProductProperty> GetProductProperty(int productPropertyId);
        Task<ProductProperty> AddProductProperty(ProductProperty productProperty);
        Task<ProductProperty> UpdateProductProperty(ProductProperty productProperty);
        Task<ProductProperty> DeleteProductProperty(int productPropertyId);
    }
}
