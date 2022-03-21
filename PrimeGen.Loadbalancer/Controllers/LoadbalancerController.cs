using Microsoft.AspNetCore.Mvc;
using PrimeGen.Loadbalancer.Service.Interface;
using PrimeGen.SharedModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimeGen.Loadbalancer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoadbalancerController : ControllerBase
    {

        private readonly ILoadBalancerService _service;
        public LoadbalancerController(ILoadBalancerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("isprime")]
        public async Task<IsPrimeResponse> IsPrime([FromQuery] string input)
        {
            return await _service.IsPrime(input);
        }

        [HttpGet]
        [Route("countprimes")]
        public async Task<PrimeIntervalResponse> CountPrimes([FromQuery] string start, string end)
        {
            return await _service.CountPrimes(start, end);
        }

    }
}
