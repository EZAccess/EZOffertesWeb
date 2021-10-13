using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SOrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;

        public SOrderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            var result = await appDbContext.Orders.AddAsync(order);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var result = await appDbContext.Orders.FirstOrDefaultAsync(e => e.OrderId == orderId);
            if (result != null)
            {
                appDbContext.Orders.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await appDbContext.Orders
                .FirstOrDefaultAsync(e => e.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await appDbContext.Orders.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            IQueryable<Order> query = appDbContext.Orders;
            query = query.Where(o => o.CustomerId == customerId);
            return await query.ToListAsync();
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var result = await appDbContext.Orders.FirstOrDefaultAsync(e => e.OrderId == order.OrderId);
            if (result != null)
            {
                result.CustomerId = order.CustomerId;
                result.EmployeeId = order.EmployeeId;
                result.OrderStatus = order.OrderStatus;
                result.OfferDate = order.OfferDate;
                result.OrderDate = order.OrderDate;
                result.IsInvoiced = order.IsInvoiced;
                result.CustomerReference = order.CustomerReference;
                result.ShippingMethodId = order.ShippingMethodId;
                result.ShippingDate = order.ShippingDate;
                result.ShippingName = order.ShippingName;
                result.ShippingAddressLine1 = order.ShippingAddressLine1;
                result.ShippingAddressLine2 = order.ShippingAddressLine2;
                result.ShippingPostalCode = order.ShippingPostalCode;
                result.ShippingCity = order.ShippingCity;
                result.ShippingState = order.ShippingState;
                result.ShippingCountry = order.ShippingCountry;
                result.ShippingPhoneNumber = order.ShippingPhoneNumber;
                result.ShippingComments = order.ShippingComments;
                result.VATTariff = order.VATTariff;
                result.DiscountPerc = order.DiscountPerc;
                result.PackingList = order.PackingList;
                result.PackingDate = order.PackingDate;
                result.Notes = order.Notes;
                result.Calc_SumAmount = order.Calc_SumAmount;
                result.Calc_TotalOffer = order.Calc_TotalOffer;
                result.Calc_TotalOrder = order.Calc_TotalOrder;
                result.Calc_TotalPaid = order.Calc_TotalPaid;
                result.Calc_TotalInvoiced = order.Calc_TotalInvoiced;
                result.RecordStatus = order.RecordStatus;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
