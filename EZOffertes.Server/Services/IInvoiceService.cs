using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetInvoices(ErrorInfo err);
        Task<Invoice> GetInvoice(int id, ErrorInfo err);
        Task<Invoice> UpdateInvoice(Invoice updatedInvoice, ErrorInfo err);
        Task<Invoice> CreateInvoice(Invoice newInvoice, ErrorInfo err);
        Task<bool> DeleteInvoice(int id, ErrorInfo err);
    }
}
