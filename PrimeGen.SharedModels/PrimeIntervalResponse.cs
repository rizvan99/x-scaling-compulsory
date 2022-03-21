using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeGen.SharedModels
{
    public class PrimeIntervalResponse
    {
        public string ConnectionString { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string TimeUsed { get; set; }

        public List<string> Result { get; set; }
    }
}
