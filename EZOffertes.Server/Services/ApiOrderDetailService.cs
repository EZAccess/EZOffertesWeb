using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiOrderDetailService : HttpService, IOrderDetailService
    {
        public ApiOrderDetailService(HttpClient httpClient) : base(httpClient) { }


        public async Task<OrderDetail> CreateOrderDetail(int orderId, OrderDetail newOrderDetail, ErrorInfo err) =>
            (await HttpPost<OrderDetail>($"api/orderdetails/{orderId}", newOrderDetail, err));

        public async Task<bool> DeleteOrderDetail(int orderId, int id, ErrorInfo err) =>
            (await HttpDelete($"api/orderdetails/{orderId}/{id}", err));

        public async Task<OrderDetail> GetOrderDetail(int orderId, int id, ErrorInfo err) =>
            (await HttpGet<OrderDetail>($"api/orderdetails/{orderId}/{id}", err));

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails(int orderId, ErrorInfo err) =>
            (await HttpGet<IEnumerable<OrderDetail>>($"api/orderdetails/{orderId}", err));

        public async Task<OrderDetail> UpdateOrderDetail(int orderId, OrderDetail updatedOrderDetail, ErrorInfo err) =>
            (await HttpPut<OrderDetail>($"api/orderdetails/{orderId}", updatedOrderDetail, err));

    }
}
