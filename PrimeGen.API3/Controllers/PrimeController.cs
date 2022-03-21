using Microsoft.AspNetCore.Mvc;
using PrimeGen.Service.Interface;
using System;
using System.Collections.Generic;

namespace PrimeGen.API3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        private readonly IPrimeService _service;

        public PrimeController(IPrimeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("isprime")]
        public ActionResult<bool> IsPrime([FromQuery] string input)
        {
            try
            {
                return Ok(_service.IsPrime(input));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("countprimes")]
        public ActionResult<List<string>> CountPrimes([FromQuery] string start, string end)
        {
            try
            {
                return Ok(_service.CountPrimes(start, end));
            }
            catch (FormatException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
