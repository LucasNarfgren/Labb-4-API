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
    public class InterestController : ControllerBase
    {
        private IInterestRepository _Interest;

        public InterestController(IInterestRepository Interest)
        {
            _Interest = Interest;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterest()
        {
                return Ok(await _Interest.GetAllInterest());
        }

        [HttpPost]
        public async Task<IActionResult> AddInterest(Interest interestToAdd)
        {
            try
            {
                if (interestToAdd == null)
                {
                    return BadRequest();
                }
                var createdInterest = await _Interest.AddInterest(interestToAdd);
                return CreatedAtAction(nameof(GetAllInterest), new { id = createdInterest.InterestId }, createdInterest);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add interest to database.");
            }
        }
    }
}
