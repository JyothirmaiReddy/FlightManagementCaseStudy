using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Models
{
    public class FlightSearch
    {
        public int FlightNo { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public int TicketCost { get; set; }
       // public string AirlineName { get; set; }
    }
}
