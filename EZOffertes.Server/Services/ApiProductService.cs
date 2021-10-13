using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiProductService : HttpService, IProductService
    {
        public ApiProductService(HttpClient httpClient) : base(httpClient) { }


        public async Task<Product> CreateProduct(Product newProduct, ErrorInfo err) =>
            (await HttpPost<Product>($"api/products", newProduct, err));

        public async Task<bool> DeleteProduct(int id, ErrorInfo err) =>
            (await HttpDelete($"api/products/{id}", err));

        public async Task<Product> GetProduct(int id, ErrorInfo err) =>
            (await HttpGet<Product>($"api/products/{id}", err));

        public async Task<IEnumerable<Product>> GetProducts(ErrorInfo err) =>
            (await HttpGet<IEnumerable<Product>>("api/products", err));

        public async Task<Product> UpdateProduct(Product updatedProduct, ErrorInfo err) =>
            (await HttpPut<Product>("api/products", updatedProduct, err));
    }
}
