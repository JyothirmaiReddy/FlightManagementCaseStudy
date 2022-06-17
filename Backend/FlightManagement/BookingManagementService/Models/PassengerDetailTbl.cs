using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Models
{
    public class PassengerDetailTbl
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public string ticketClass { get; set; }
    }
    public enum gender
    { 
        Male,
        Female,
        Others
    }

}
