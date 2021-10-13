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
    public class ShippingMethodsController : ControllerBase
    {
        private readonly IShippingMethodRepository shippingMethodRepository;

        public ShippingMethodsController(IShippingMethodRepository shippingMethodRepository)
        {
            this.shippingMethodRepository = shippingMethodRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetShippingMethods()
        {
            try
            {
                return Ok(await shippingMethodRepository.GetShippingMethods());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShippingMethod>> GetShippingMethod(int id)
        {
            try
            {
                var result = await shippingMethodRepository.GetShippingMethod(id);
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

        [HttpPost]
        public async Task<ActionResult<ShippingMethod>> CreateShippingMethod(ShippingMethod ShippingMethod)
        {
            try
            {
                if (ShippingMethod == null)
                {
                    return BadRequest();
                }

                var createdShippingMethod = await shippingMethodRepository.AddShippingMethod(ShippingMethod);
                return CreatedAtAction(nameof(GetShippingMethod), new { id = createdShippingMethod.ShippingMethodId }, createdShippingMethod);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<ShippingMethod>> UpdateShippingMethod(ShippingMethod ShippingMethod)
        {
            try
            {
                var ShippingMethodToUpdate = await shippingMethodRepository.GetShippingMethod(ShippingMethod.ShippingMethodId);
                if (ShippingMethodToUpdate == null)
                {
                    return NotFound($"ShippingMethod with id = {ShippingMethod.ShippingMethodId} not found");
                }

                return await shippingMethodRepository.UpdateShippingMethod(ShippingMethod);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ShippingMethod>> DeleteShippingMethod(int id)
        {
            try
            {
                var ShippingMethodToDelete = await shippingMethodRepository.GetShippingMethod(id);
                if (ShippingMethodToDelete == null)
                {
                    return NotFound($"ShippingMethod with id = {id} not found");
                }

                return await shippingMethodRepository.DeleteShippingMethod(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
