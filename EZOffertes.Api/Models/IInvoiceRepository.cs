using EZOffertes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> Search(int invoiceNumber);
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<Invoice> GetInvoice(int invoiceId);
        Task<Invoice> AddInvoice(Invoice invoice);
        Task<Invoice> UpdateInvoice(Invoice invoice);
        Task<Invoice> DeleteInvoice(int invoiceId);
    }
}
