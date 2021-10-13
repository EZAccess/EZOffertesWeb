using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersOfCustomer(int id, ErrorInfo err);
        Task<IEnumerable<Order>> GetOrders(ErrorInfo err);
        Task<Order> GetOrder(int id, ErrorInfo err);
        Task<Order> UpdateOrder(Order updatedOrder, ErrorInfo err);
        Task<Order> CreateOrder(Order newOrder, ErrorInfo err);
        Task<bool> DeleteOrder(int id, ErrorInfo err);

    }
}
