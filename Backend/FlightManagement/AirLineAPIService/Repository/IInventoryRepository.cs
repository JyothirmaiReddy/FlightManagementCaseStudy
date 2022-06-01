using AirLineAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Repository
{
    public interface IInventoryRepository
    {
        bool AddInventory(Inventory obj);

        IEnumerable<FlightSearch> GetFlights(string FromPlace, string ToPlace, bool IsOneway, bool IsRoundTrip);

       
    }
}
