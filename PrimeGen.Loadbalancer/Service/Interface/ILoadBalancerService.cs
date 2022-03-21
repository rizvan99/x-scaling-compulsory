using PrimeGen.SharedModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimeGen.Loadbalancer.Service.Interface
{
    public interface ILoadBalancerService
    {
        /// <summary>
        /// Async return of boolean value
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<IsPrimeResponse> IsPrime(string input);

        /// <summary>
        /// Async return of prime numbers between interval
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Task<PrimeIntervalResponse> CountPrimes(string start, string end);
    }
}
