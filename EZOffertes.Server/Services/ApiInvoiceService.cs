using EZOffertes.Models;
using EZOffertes.Server.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EZOffertes.Server.Services
{
    public class ApiInvoiceService : HttpService, IInvoiceService
    {
        public ApiInvoiceService(HttpClient httpClient) : base(httpClient) { }


        public async Task<Invoice> CreateInvoice(Invoice newInvoice, ErrorInfo err) =>
            (await HttpPost<Invoice>($"api/invoices", newInvoice, err));

        public async Task<bool> DeleteInvoice(int id, ErrorInfo err) =>
            (await HttpDelete($"api/invoices/{id}", err));

        public async Task<Invoice> GetInvoice(int id, ErrorInfo err) =>
            (await HttpGet<Invoice>($"api/invoices/{id}", err));

        public async Task<IEnumerable<Invoice>> GetInvoices(ErrorInfo err) =>
            (await HttpGet<IEnumerable<Invoice>>("api/invoices", err));

        public async Task<Invoice> UpdateInvoice(Invoice updatedInvoice, ErrorInfo err) =>
            (await HttpPut<Invoice>("api/invoices", updatedInvoice, err));

    }
}
