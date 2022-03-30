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
    public class LinkController : ControllerBase
    {
        private ILinkRepository _Links;

        public LinkController(ILinkRepository links)
        {
            _Links = links;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            return Ok(await _Links.GetAllLinks());
        }

        [HttpPost]
        public async Task<IActionResult> AddLink(Link linkToAdd)
        {
            try
            {
                if (linkToAdd == null)
                {
                    return BadRequest();
                }
                var createdLink = await _Links.AddLink(linkToAdd);
                return CreatedAtAction(nameof(GetAllLinks), new { id = createdLink.LinkId }, createdLink);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add interest to database.");
            }
        }
    }
}
