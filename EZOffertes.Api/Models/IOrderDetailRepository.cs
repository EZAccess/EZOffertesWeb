using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrder(int orderId);
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
        Task<OrderDetail> GetOrderDetail(int orderDetailId);
        Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> DeleteOrderDetail(int orderDetailId);
    }
}
