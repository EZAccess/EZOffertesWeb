using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiProductCategoryService : HttpService, IProductCategoryService
    {
        public ApiProductCategoryService(HttpClient httpClient) : base(httpClient) { }


        public async Task<ProductCategory> CreateProductCategory(ProductCategory newProductCategory, ErrorInfo err) =>
            (await HttpPost<ProductCategory>($"api/productcategories", newProductCategory, err));

        public async Task<bool> DeleteProductCategory(int id, ErrorInfo err) =>
            (await HttpDelete($"api/productcategories/{id}", err));

        public async Task<ProductCategory> GetProductCategory(int id, ErrorInfo err) =>
            (await HttpGet<ProductCategory>($"api/productcategories/{id}", err));

        public async Task<IEnumerable<ProductCategory>> GetProductCategories(ErrorInfo err) =>
            (await HttpGet<IEnumerable<ProductCategory>>("api/productcategories", err));

        public async Task<ProductCategory> UpdateProductCategory(ProductCategory updatedProductCategory, ErrorInfo err) =>
            (await HttpPut<ProductCategory>("api/productcategories", updatedProductCategory, err));

    }
}
