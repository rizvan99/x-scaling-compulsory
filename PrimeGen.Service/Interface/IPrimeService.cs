using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGen.Service.Interface
{
    public interface IPrimeService
    {
        /// <summary>
        /// Determines whether or not the input is a prime number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsPrime(string input);

        /// <summary>
        /// Count the amount of prime numbers between start and end input
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<string> CountPrimes(string start, string end);
    }
}
