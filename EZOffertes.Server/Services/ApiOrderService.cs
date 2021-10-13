using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiOrderService : HttpService, IOrderService
    {
        public ApiOrderService(HttpClient httpClient) : base(httpClient) { }


        public async Task<Order> CreateOrder(Order newOrder, ErrorInfo err) =>
            (await HttpPost<Order>($"api/orders", newOrder, err));

        public async Task<bool> DeleteOrder(int id, ErrorInfo err) =>
            (await HttpDelete($"api/orders/{id}", err));

        public async Task<Order> GetOrder(int id, ErrorInfo err) =>
            (await HttpGet<Order>($"api/orders/{id}", err));

        public async Task<IEnumerable<Order>> GetOrders(ErrorInfo err) =>
            (await HttpGet<IEnumerable<Order>>("api/orders", err));

        public async Task<IEnumerable<Order>> GetOrdersOfCustomer(int id, ErrorInfo err) =>
            (await HttpGet<IEnumerable<Order>>($"api/orders/ofcustomer{id}", err));

        public async Task<Order> UpdateOrder(Order updatedOrder, ErrorInfo err) =>
            (await HttpPut<Order>("api/orders", updatedOrder, err));

    }
}
