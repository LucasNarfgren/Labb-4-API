using Labb4.API.Services;
using Labb4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetSinglePerson(int id)
        {
            return Ok(await _personRepo.GetSinglePerson(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            return Ok(await _personRepo.GetAllPersons());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            try
            {
                var persontoDelete = await _personRepo.GetSinglePerson(id);
                if (persontoDelete == null)
                {
                    return NotFound($"Person with ID {id} was not found");
                }
                return Ok(await _personRepo.DeletePerson(persontoDelete));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete person from database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person person)
        {
            try
            {
                if (id != person.PersonId)
                {
                    return BadRequest($"Person with ID {id} does not exist.");
                }
                var persontoUpdate = await _personRepo.GetSinglePerson(id);
                if (persontoUpdate == null)
                {
                    return NotFound($"Person with ID {id} was not found.");
                }
                return Ok(await _personRepo.UpdatePerson(person));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(Person PersontoAdd)
        {
            try
            {
                if (PersontoAdd == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _personRepo.AddPerson(PersontoAdd);
                return CreatedAtAction(nameof(GetSinglePerson), new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add person to database.");
            }
        }
    }
}
