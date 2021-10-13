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
    public class UnitsOfMeasureController : ControllerBase
    {
        private readonly IUnitOfMeasureRepository unitOfMeasureRepository;

        public UnitsOfMeasureController(IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            this.unitOfMeasureRepository = unitOfMeasureRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUnitsOfMeasure()
        {
            try
            {
                return Ok(await unitOfMeasureRepository.GetUnitsOfMeasure());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UnitOfMeasure>> GetUnitOfMeasure(int id)
        {
            try
            {
                var result = await unitOfMeasureRepository.GetUnitOfMeasure(id);
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
        public async Task<ActionResult<UnitOfMeasure>> CreateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            try
            {
                if (unitOfMeasure == null)
                {
                    return BadRequest();
                }

                var createdUnitOfMeasure = await unitOfMeasureRepository.AddUnitOfMeasure(unitOfMeasure);
                return CreatedAtAction(nameof(GetUnitOfMeasure), new { id = createdUnitOfMeasure.UnitOfMeasureId }, createdUnitOfMeasure);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<UnitOfMeasure>> UpdateUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            if (unitOfMeasure is null)
            {
                return BadRequest();
            }
            try
            {
                var UnitOfMeasureToUpdate = await unitOfMeasureRepository.GetUnitOfMeasure(unitOfMeasure.UnitOfMeasureId);
                if (UnitOfMeasureToUpdate == null)
                {
                    return NotFound($"UnitOfMeasure with id = {unitOfMeasure.UnitOfMeasureId} not found");
                }

                return await unitOfMeasureRepository.UpdateUnitOfMeasure(unitOfMeasure);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<UnitOfMeasure>> DeleteUnitOfMeasure(int id)
        {
            try
            {
                var UnitOfMeasureToDelete = await unitOfMeasureRepository.GetUnitOfMeasure(id);
                if (UnitOfMeasureToDelete == null)
                {
                    return NotFound($"UnitOfMeasure with id = {id} not found");
                }

                return await unitOfMeasureRepository.DeleteUnitOfMeasure(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
