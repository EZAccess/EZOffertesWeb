using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SPaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext appDbContext;

        public SPaymentRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Payment> AddPayment(Payment payment)
        {
            var result = await appDbContext.Payments.AddAsync(payment);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Payment> DeletePayment(int paymentId)
        {
            var result = await appDbContext.Payments.FirstOrDefaultAsync(e => e.PaymentId == paymentId);
            if (result != null)
            {
                appDbContext.Payments.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Payment> GetPayment(int paymentId)
        {
            return await appDbContext.Payments
                .FirstOrDefaultAsync(e => e.PaymentId == paymentId);
        }

        public async Task<IEnumerable<Payment>> GetPayments()
        {
            return await appDbContext.Payments.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByOrder(int orderId)
        {
            IQueryable<Payment> query = appDbContext.Payments;
            query = query.Where(e => e.OrderId == orderId);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByInvoice(int invoiceId)
        {
            IQueryable<Payment> query = appDbContext.Payments;
            query = query.Where(e => e.InvoiceId == invoiceId);
            return await query.ToListAsync();
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            var result = await appDbContext.Payments.FirstOrDefaultAsync(e => e.PaymentId == payment.PaymentId);
            if (result != null)
            {
                result.OrderId = payment.OrderId;
                result.InvoiceId = payment.InvoiceId;
                result.PaymentType = payment.PaymentType;
                result.Amount = payment.Amount;
                result.PaymentDate = payment.PaymentDate;
                result.EmployeeId = payment.EmployeeId;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;

                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
