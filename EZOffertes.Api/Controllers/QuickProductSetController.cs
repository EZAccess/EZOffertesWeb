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
    public class QuickProductSetsController : ControllerBase
    {
        private readonly IQuickProductSetRepository quickProductSetRepository;

        public QuickProductSetsController(IQuickProductSetRepository QuickProductSetRepository)
        {
            this.quickProductSetRepository = QuickProductSetRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetQuickProductSets()
        {
            try
            {
                return Ok(await quickProductSetRepository.GetQuickProductSets());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<QuickProductSet>> GetQuickProductSet(int id)
        {
            try
            {
                var result = await quickProductSetRepository.GetQuickProductSet(id);
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
        public async Task<ActionResult<IEnumerable<QuickProductSet>>> Search(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await quickProductSetRepository.Search(name);
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
        public async Task<ActionResult<QuickProductSet>> CreateQuickProductSet(QuickProductSet quickProductSet)
        {
            try
            {
                if (quickProductSet == null)
                {
                    return BadRequest();
                }

                var createdQuickProductSet = await quickProductSetRepository.AddQuickProductSet(quickProductSet);
                return CreatedAtAction(nameof(GetQuickProductSet), new { id = createdQuickProductSet.QuickProductSetId }, createdQuickProductSet);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<QuickProductSet>> UpdateQuickProductSet(QuickProductSet quickProductSet)
        {
            try
            {
                var QuickProductSetToUpdate = await quickProductSetRepository.GetQuickProductSet(quickProductSet.QuickProductSetId);
                if (QuickProductSetToUpdate == null)
                {
                    return NotFound($"QuickProductSet with id = {quickProductSet.QuickProductSetId} not found");
                }

                return await quickProductSetRepository.UpdateQuickProductSet(quickProductSet);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<QuickProductSet>> DeleteQuickProductSet(int id)
        {
            try
            {
                var QuickProductSetToDelete = await quickProductSetRepository.GetQuickProductSet(id);
                if (QuickProductSetToDelete == null)
                {
                    return NotFound($"QuickProductSet with id = {id} not found");
                }

                return await quickProductSetRepository.DeleteQuickProductSet(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
