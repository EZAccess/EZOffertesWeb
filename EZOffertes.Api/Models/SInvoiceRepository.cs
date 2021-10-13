using EZOffertes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api.Models
{
    public class SInvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext appDbContext;

        public SInvoiceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Invoice> AddInvoice(Invoice invoice)
        {
            var result = await appDbContext.Invoices.AddAsync(invoice);
            result.Entity.TsCreated = System.DateTime.Now;
            result.Entity.TsUpdated = System.DateTime.Now;
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Invoice> DeleteInvoice(int invoiceId)
        {
            var result = await appDbContext.Invoices.FirstOrDefaultAsync(e => e.InvoiceId == invoiceId);
            if (result != null)
            {
                appDbContext.Invoices.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Invoice> GetInvoice(int invoiceId)
        {
            return await appDbContext.Invoices
                .FirstOrDefaultAsync(e => e.InvoiceId == invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await appDbContext.Invoices.ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> Search(int invoiceNumber)
        {
            IQueryable<Invoice> query = appDbContext.Invoices;
            query = query.Where(e => e.InvoiceNumber == invoiceNumber);
            return await query.ToListAsync();
        }

        public async Task<Invoice> UpdateInvoice(Invoice invoice)
        {
            var result = await appDbContext.Invoices.FirstOrDefaultAsync(e => e.InvoiceId == invoice.InvoiceId);
            if (result != null)
            {
                result.CustomerId = invoice.CustomerId;
                result.OrderId = invoice.OrderId;
                result.InvoiceNumber = invoice.InvoiceNumber;
                result.InvoiceDate = invoice.InvoiceDate;
                result.InvoiceStatus = invoice.InvoiceStatus;
                result.DateReminder = invoice.DateReminder;
                result.DateWarning = invoice.DateWarning;
                result.VATTariff = invoice.VATTariff;
                result.DiscountPerc = invoice.DiscountPerc;
                result.Calc_AmountGrossIncl = invoice.Calc_AmountGrossIncl;
                result.Calc_AmountGrossExcl = invoice.Calc_AmountGrossExcl;
                result.Calc_AmountDiscountIncl = invoice.Calc_AmountDiscountIncl;
                result.Calc_AmountDiscountExcl = invoice.Calc_AmountDiscountExcl;
                result.Calc_AmountVAT = invoice.Calc_AmountVAT;
                result.Calc_AmountIncl = invoice.Calc_AmountIncl;
                result.Calc_AmountExcl = invoice.Calc_AmountExcl;
                result.TsCreated = result.TsCreated;
                result.TsUpdated = System.DateTime.Now;
                await appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }
    }
}
