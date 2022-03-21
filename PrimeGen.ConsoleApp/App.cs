using Newtonsoft.Json;
using PrimeGen.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGen.ConsoleApp
{
    public class App
    {

        HttpClient _client = new HttpClient();

        public App()
        {

        }

        public void Run()
        {
            string[] menuItems =
            {
                "Check if a number is a prime number",
                "Give me prime numbers based on interval",
                "Demo multiple requests",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 4)
            {
                switch (selection)
                {
                    case 1:
                        HandleCheckPrime();
                        break;
                    case 2:
                        HandlePrimeInterval();
                        break;
                    case 3:
                        MultipleRequests();
                        break;
                    default:
                        Console.WriteLine("Closing the program");
                        break;
                }

                selection = ShowMenu(menuItems);
            }
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("SELECT YOUR CHOICE");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {menuItems[i]}");
            }

            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please input a number between 1-4");
            }

            return selection;
        }

        private void HandleCheckPrime()
        {
            Console.WriteLine("Enter a number");
            var num = Console.ReadLine();
            Task<HttpResponseMessage> response = _client.GetAsync("https://localhost:44347/Prime/isprime?input=" + num);
            String result = response.Result.Content.ReadAsStringAsync().Result;
            if (result == "true")
            {
                Console.WriteLine(num + " is a prime number!");
            }
            else if (result == "false")
            {
                Console.WriteLine(num + " is not a prime number");
            }
            else
            {
                Console.WriteLine("Error occurred");
            }
        }

        private void HandlePrimeInterval()
        {
            Console.WriteLine("Enter start value");
            var startValue = Console.ReadLine();
            Console.WriteLine("Enter end value");
            var endValue = Console.ReadLine();
            Task<HttpResponseMessage> response = _client.GetAsync("https://localhost:44347/Prime/countprimes?start=" + startValue + "&end=" + endValue);
            String result = response.Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        private void MultipleRequests()
        {
            var startTime = DateTime.Now;

            Random r = new Random();

            Console.WriteLine("========== REQUEST STARTED AT: " + startTime);

            for (var i = 0; i < 25; i++)
            {
                var response = _client.GetAsync("https://localhost:44350/Loadbalancer/" + "isprime?input=" + r.Next(1, 100));
                var result = response.Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }

            var endTime = DateTime.Now;

            
            Console.WriteLine("========== FINISHED 10 REQUEST AT: " + endTime);
        }
    }
}
