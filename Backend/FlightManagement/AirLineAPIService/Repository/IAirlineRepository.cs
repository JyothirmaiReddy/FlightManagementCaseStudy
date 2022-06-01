using AirLineAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Repository
{
    public interface IAirlineRepository
    {
        void AddAirline(Airline airlineobj);
       IEnumerable<Airline> GetAirlines();

        Airline GetAirlinebyNumber(int airlineno);
        void  DeleteAirline(int airlineno);

        void BlockAirline(int airlineno);
    }
}
