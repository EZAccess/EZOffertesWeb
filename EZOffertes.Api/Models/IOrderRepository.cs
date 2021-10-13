using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrder(int orderId);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<Order> DeleteOrder(int orderId);
    }
}
