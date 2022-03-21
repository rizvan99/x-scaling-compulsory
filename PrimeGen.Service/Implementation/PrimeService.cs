using PrimeGen.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGen.Service.Implementation
{
    public class PrimeService : IPrimeService
    {
        public List<string> CountPrimes(string start, string end)
        {
            int numStart;
            int numEnd;

            List<string> output = new List<string>();

            bool isNumStart = Int32.TryParse(start, out numStart);
            bool isNumEnd = Int32.TryParse(end, out numEnd);

            if (!isNumStart || !isNumEnd)
            {
                throw new FormatException("Numbers were not provided");
            }

            for (int i = numStart; i < numEnd; i++)
            {
                int s = 0;
                if (i > 1)
                {
                    for (int j = 2; j < i; j++)
                    {
                        if (i % j == 0)
                        {
                            s = 1;
                            break;
                        }
                    }
                    if (s == 0)
                    {
                        output.Add(i.ToString());
                    }
                }
            }

            return output;
        }

        public bool IsPrime(string input)
        {
            int number;

            bool isNum = Int32.TryParse(input, out number);

            if (!isNum)
            {
                throw new FormatException("A number was not provided");
            }

            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
