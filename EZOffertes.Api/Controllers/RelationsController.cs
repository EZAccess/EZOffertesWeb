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
    public class RelationsController : ControllerBase
    {
        private readonly IRelationRepository relationRepository;

        public RelationsController(IRelationRepository relationRepository)
        {
            this.relationRepository = relationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetRelations()
        {
            try
            {
                return Ok(await relationRepository.GetRelations());
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.InnerException.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Relation>> GetRelation(int id)
        {
            try
            {
                var result = await relationRepository.GetRelation(id);
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
        public async Task<ActionResult<IEnumerable<Relation>>> Search(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            try
            {
                var result = await relationRepository.Search(name);
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
        public async Task<ActionResult<Relation>> CreateRelation(Relation relation)
        {
            try
            {
                if (relation == null)
                {
                    return BadRequest();
                }

                var createdRelation = await relationRepository.AddRelation(relation);
                return CreatedAtAction(nameof(GetRelation), new { id = createdRelation.RelationId }, createdRelation);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error inserting data in the database {e}");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Relation>> UpdateRelation(Relation relation)
        {
            try
            {
                var relationToUpdate = await relationRepository.GetRelation(relation.RelationId);
                if (relationToUpdate == null)
                {
                    return NotFound($"Relation with id = {relation.RelationId} not found");
                }

                return await relationRepository.UpdateRelation(relation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Relation>> DeleteRelation(int id)
        {
            try
            {
                var relationToDelete = await relationRepository.GetRelation(id);
                if (relationToDelete == null)
                {
                    return NotFound($"Relation with id = {id} not found");
                }

                return await relationRepository.DeleteRelation(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
