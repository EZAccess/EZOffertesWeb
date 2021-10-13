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
    public class PersonTitlesController : ControllerBase
    {
        private readonly IPersonTitleRepository personTitleRepository;

        public PersonTitlesController(IPersonTitleRepository personTitleRepository)
        {
            this.personTitleRepository = personTitleRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPersonTitles()
        {
            try
            {
                return Ok(await personTitleRepository.GetPersonTitles());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonTitle>> GetPersonTitle(int id)
        {
            try
            {
                var result = await personTitleRepository.GetPersonTitle(id);
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
        public async Task<ActionResult<PersonTitle>> CreatePersonTitle(PersonTitle personTitle)
        {
            try
            {
                if (personTitle == null)
                {
                    return BadRequest();
                }

                var createdPersonTitle = await personTitleRepository.AddPersonTitle(personTitle);
                return CreatedAtAction(nameof(GetPersonTitle), new { id = createdPersonTitle.PersonTitleId }, createdPersonTitle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error inserting data in the database");
            }
        }

        [HttpPut]
        public async Task<ActionResult<PersonTitle>> UpdatePersonTitle(PersonTitle personTitle)
        {
            try
            {
                var PersonTitleToUpdate = await personTitleRepository.GetPersonTitle(personTitle.PersonTitleId);
                if (PersonTitleToUpdate == null)
                {
                    return NotFound($"PersonTitle with id = {personTitle.PersonTitleId} not found");
                }

                return await personTitleRepository.UpdatePersonTitle(personTitle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PersonTitle>> DeletePersonTitle(int id)
        {
            try
            {
                var PersonTitleToDelete = await personTitleRepository.GetPersonTitle(id);
                if (PersonTitleToDelete == null)
                {
                    return NotFound($"PersonTitle with id = {id} not found");
                }

                return await personTitleRepository.DeletePersonTitle(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }
    }
}
