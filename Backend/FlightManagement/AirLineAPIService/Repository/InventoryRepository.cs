using AirLineAPIService.DbContext;
using AirLineAPIService.Models;
using MassTransit;
using RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Repository
{
    public class InventoryRepository : IInventoryRepository,IConsumer<RMQData>
    {
        private readonly AppDbContext context;

        public InventoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public bool AddInventory(Inventory obj)
        {
            var result = context.Inventories.Where(i => i.FlightNumber == obj.FlightNumber).ToList();
            if (result.Count == 0)
            {
                context.Inventories.Add(obj);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task Consume(ConsumeContext<RMQData> contextmq)
        {
            int flightNo = contextmq.Message.flightNumber;
            var inventory = context.Inventories.Find(flightNo);
            inventory.BusinessSeats = inventory.BusinessSeats - contextmq.Message.businessSeats;
            inventory.NonBusinessSeats = inventory.NonBusinessSeats - contextmq.Message.nonbusinessSeats;
            context.Entry(inventory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public IEnumerable<FlightSearch> GetFlights(string FromPlace, string ToPlace, bool IsOneway, bool IsRoundTrip)
        {
            List<FlightSearch> res = new List<FlightSearch>();
            var ListOfFlights = context.Inventories.Where(e => e.Fromplace == FromPlace && e.Toplace == ToPlace&& e.Airlines.IsBlocked==false).ToList();
            if (ListOfFlights.Count > 0)
            {
                foreach (var data in ListOfFlights)
                {
                    FlightSearch temp = new FlightSearch();
                    temp.FromPlace = data.Fromplace;
                    temp.ToPlace = data.Toplace;
                    temp.FlightNo = data.FlightNumber;
                    temp.startTime = data.startDatetime;
                    temp.endTime = data.EndDatetime;
                    //temp.AirlineName = data.Airlines.airlineLogo;
                    if (IsOneway)
                        temp.TicketCost = data.ticketCost;
                    else
                        temp.TicketCost = 2 * (data.ticketCost);
                    res.Add(temp);
                }
            }
            return res;
            
        }
    }
}
