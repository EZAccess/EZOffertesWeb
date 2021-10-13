using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetPaymentsByOrder(int orderId);
        Task<IEnumerable<Payment>> GetPaymentsByInvoice(int invoiceId);
        Task<IEnumerable<Payment>> GetPayments();
        Task<Payment> GetPayment(int paymentId);
        Task<Payment> AddPayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task<Payment> DeletePayment(int paymentId);
    }
}
