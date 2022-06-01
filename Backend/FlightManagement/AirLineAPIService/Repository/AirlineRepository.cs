using AirLineAPIService.DbContext;
using AirLineAPIService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Repository
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly AppDbContext context;

        public AirlineRepository(AppDbContext context)
        {
            this.context = context;
        }

        public  void  AddAirline(Airline airlineobj)
        {
            context.Airlines.Add(airlineobj);
             context.SaveChanges();
        }

        public void BlockAirline(int airlineno)
        {
            var airlineToBlock = context.Airlines.Find(airlineno);
            if(airlineToBlock != null)
            {
                airlineToBlock.IsBlocked = true;
                context.SaveChanges();
            }
        }

        public void DeleteAirline(int AirlineNo)
        {
            Airline airlinetodelete = context.Airlines.Find(AirlineNo);

            if(airlinetodelete!=null)
            {
                context.Airlines.Remove(airlinetodelete);
                context.SaveChanges();
            }

            
        }

        public Airline GetAirlinebyNumber(int airlineno)
        {
            return context.Airlines.FirstOrDefault(a => a.AirlineNo == airlineno);
        }

        public IEnumerable<Airline> GetAirlines()
        {
            return context.Airlines;
        }
    }
}
