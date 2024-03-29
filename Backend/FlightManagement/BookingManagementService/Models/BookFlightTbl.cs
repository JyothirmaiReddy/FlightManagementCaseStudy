﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Models
{
    public class BookFlightTbl
    {
        public int FlightNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public  DateTime Stime { get; set; }

        public DateTime Etime { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }
        public PassengerDetailTbl[] passengers { get; set; }
    }
}
