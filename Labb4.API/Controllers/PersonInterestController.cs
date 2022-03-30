using Labb4.API.Services;
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
    public class PersonInterestController : ControllerBase
    {
        private IPersonRepository _personRepo;

        public PersonInterestController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Getinterestwithperson(int id)
        {
            return Ok(await _personRepo.GetinterestwithPerson(id));
        }
    }
}
