using Newtonsoft.Json;
using PrimeGen.Loadbalancer.Service.Interface;
using PrimeGen.SharedModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PrimeGen.Loadbalancer.Service.Implementation
{
    public class LoadBalancerService : ILoadBalancerService
    {
        private readonly ServerConfig _config;
        private readonly HttpClient _client;
        private int _previousVal = 0;

        public LoadBalancerService(ServerConfig config)
        {
            _config = config;
            _client = new HttpClient();
        }

        private string FetchRandomServer()
        {
            Random r = new Random();
            int rNum = r.Next(0, 3);

            while (_previousVal == rNum)
            {
                rNum = r.Next(0, 3);
            }

            _previousVal = rNum;

            return _config.Servers[rNum];
        }

        public async Task<PrimeIntervalResponse> CountPrimes(string start, string end)
        {
            var startTime = DateTime.Now;

            var connString = FetchRandomServer();
            var response = await _client.GetAsync(connString + "countprimes?start=" + start + "&end=" + end);

            var responseContent = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());

            var endTime = DateTime.Now;
            TimeSpan timeSpent = endTime - startTime;

            var result = new PrimeIntervalResponse()
            {
                Start = startTime,
                End = endTime,
                TimeUsed = timeSpent.ToString(@"hh\:mm\:ss\:fff"),
                ConnectionString = connString,
                Result = responseContent
            };

            return result;
        }

        public async Task<IsPrimeResponse> IsPrime(string input)
        {
            var startTime = DateTime.Now;

            var connString = FetchRandomServer();
            var response = await _client.GetAsync(connString + "isprime?input=" + input);

            var responseContent = JsonConvert.DeserializeObject<bool>(await response.Content.ReadAsStringAsync());

            var endTime = DateTime.Now;
            TimeSpan timeSpent = endTime - startTime;

            var result = new IsPrimeResponse()
            {
                Start = startTime,
                End = endTime,
                TimeUsed = timeSpent.ToString(@"hh\:mm\:ss\:fff"),
                ConnectionString = connString,
                Result = responseContent
            };

            return result;
        }
    }
}
