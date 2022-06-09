using AirLineAPIService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Models
{
    public class TicketDetailTbl
    {
        [Key]

        public int userid { get; set; }
        public int FlightNumber { get; set; }
        public DateTime startingTime { get; set; }
        public DateTime endingTime { get; set; }
        /* [ForeignKey("FlightNumber")]
         public Inventory Inventories { get; set; }*/
        public string passengerName { get; set; }
        public int passengerAge { get; set; }
        public gender passengerGender { get; set; }
        public string  PNR { get; set; }
        public string Email { get; set; }
    }
}
