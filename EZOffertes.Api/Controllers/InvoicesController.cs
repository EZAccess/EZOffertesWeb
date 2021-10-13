using EZOffertes.Models;
using EZOffertes.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace EZOffertes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository invoiceRepository;

        public InvoicesController(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetInvoices()
        {
            try
            {
                return Ok(await invoiceRepository.GetInvoices());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            try
            {
                var result = await invoiceRepository.GetInvoice(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Invoice>>> Search(int invoiceNumber)
        {
            if (invoiceNumber == 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await invoiceRepository.Search(invoiceNumber);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Invoice>> CreateInvoice(Invoice invoice)
        {
            try
            {
                if (invoice == null)
                {
                    return BadRequest();
                }

                var createdInvoice = await invoiceRepository.AddInvoice(invoice);
                return CreatedAtAction(nameof(GetInvoice), new { id = createdInvoice.InvoiceId }, createdInvoice);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Invoice>> UpdateInvoice(Invoice invoice)
        {
            try
            {
                var invoiceToUpdate = await invoiceRepository.GetInvoice(invoice.InvoiceId);
                if (invoiceToUpdate == null)
                {
                    return NotFound($"Invoice with id = {invoice.InvoiceId} not found");
                }

                return await invoiceRepository.UpdateInvoice(invoice);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Invoice>> DeleteInvoice(int id)
        {
            try
            {
                var invoiceToDelete = await invoiceRepository.GetInvoice(id);
                if (invoiceToDelete == null)
                {
                    return NotFound($"Invoice with id = {id} not found");
                }

                return await invoiceRepository.DeleteInvoice(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
