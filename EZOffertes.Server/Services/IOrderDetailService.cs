using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetails(int orderId, ErrorInfo err);
        Task<OrderDetail> GetOrderDetail(int orderId, int id, ErrorInfo err);
        Task<OrderDetail> UpdateOrderDetail(int orderId, OrderDetail updatedOrderDetail, ErrorInfo err);
        Task<OrderDetail> CreateOrderDetail(int orderId, OrderDetail newOrderDetail, ErrorInfo err);
        Task<bool> DeleteOrderDetail(int orderId, int id, ErrorInfo err);

    }
}
