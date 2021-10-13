using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SOrderDetailRepository : IOrderDetailRepository
    {
        private readonly AppDbContext appDbContext;

        public SOrderDetailRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail.ProductId == 0) 
            {
                orderDetail.ProductId = null;
            }
            var result = await appDbContext.OrderDetails.AddAsync(orderDetail);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<OrderDetail> DeleteOrderDetail(int orderDetailId)
        {
            var result = await appDbContext.OrderDetails.FirstOrDefaultAsync(e => e.OrderDetailId == orderDetailId);
            if (result != null)
            {
                appDbContext.OrderDetails.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<OrderDetail> GetOrderDetail(int orderDetailId)
        {
            return await appDbContext.OrderDetails
                .FirstOrDefaultAsync(e => e.OrderDetailId == orderDetailId);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await appDbContext.OrderDetails.ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrder(int orderId)
        {
            IQueryable<OrderDetail> query = appDbContext.OrderDetails;
            query = query.Where(e => e.OrderId == orderId);
            return await query.ToListAsync();
        }

        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var result = await appDbContext.OrderDetails.FirstOrDefaultAsync(e => e.OrderDetailId == orderDetail.OrderDetailId);
            if (result != null)
            {
                if (result.OrderId != orderDetail.OrderId)
                {
                    return null;
                }
                
                result.Sequence = orderDetail.Sequence;
                result.ProjectName = orderDetail.ProjectName;
                result.ProductCategory = orderDetail.ProjectName;
                result.ProductId = orderDetail.ProductId;
                result.TextOffer = orderDetail.TextOffer;
                result.TextOrder = orderDetail.TextOrder ;
                result.Quantity = orderDetail.Quantity;
                result.Unit = orderDetail.Unit;
                result.Price = orderDetail.Price;
                result.Calc_DetailAmount = orderDetail.Calc_DetailAmount;
                result.SupplierId = orderDetail.SupplierId;
                result.SupplierStatus = orderDetail.SupplierStatus;
                result.SupplierArticleNumber = orderDetail.SupplierArticleNumber;
                result.SupplierProductDescription = orderDetail.SupplierProductDescription;
                result.SupplierComment = orderDetail.SupplierComment;
                result.SupplierOrderDate = orderDetail.SupplierOrderDate;
                result.SupplierOrderReference = orderDetail.SupplierOrderReference;
                result.SupplierConfirmDate = orderDetail.SupplierConfirmDate;
                result.SupplierDeliveryDate = orderDetail.SupplierDeliveryDate;
                result.ShippingStatus = orderDetail.ShippingStatus;
                result.PackListId = orderDetail.PackListId;
                result.ParentOrderDetailId = orderDetail.ParentOrderDetailId;
                result.IsInternalComment = orderDetail.IsInternalComment;
                result.ActionSelect = orderDetail.ActionSelect;
                result.InvoiceId = orderDetail.InvoiceId;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;
                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
