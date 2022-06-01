using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Models
{
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FlightNumber { get; set; }
        public int FK_AirlineNo { get; set; }
        [ForeignKey("FK_AirlineNo")]
        public Airline Airlines { get; set; }
        public string Fromplace { get; set; }
        public string Toplace { get; set; }
        public DateTime startDatetime { get; set; }
        public DateTime EndDatetime { get; set; }
        public int BusinessSeats { get; set; }
        public int NonBusinessSeats { get; set; }
        public int ticketCost { get; set; }
        public int NumberOfRows { get; set; }
        public Meal meal { get; set; }
        public InstrumentUsed instrumentUsed { get; set; }


    }
    public enum Meal
    { 
        Veg,
        Nonveg
    }
    public enum InstrumentUsed
    {
        A320,
        A320Neo
    }


}
