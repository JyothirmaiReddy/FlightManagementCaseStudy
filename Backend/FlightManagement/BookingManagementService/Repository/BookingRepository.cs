using BookingManagementService.Appdbcontext;
using BookingManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Repository
{
    public class BookingRepository : IbookingRepository
    {
        private readonly AppDbContext context;

        public BookingRepository(AppDbContext context)
        {
            this.context = context;
        }
        public string AddBooking(BookFlightTbl obj)
        {
  
            Random generaterandom = new Random();
            var rnumber = generaterandom.Next(0, 1000);
            string pnr = "PNR" + rnumber;
            foreach(var temp in obj.passengers)
             {
                 TicketDetailTbl data = new TicketDetailTbl();
                 data.FlightNumber = obj.FlightNo;
                 data.passengerAge = temp.Age;
                data.passengerName = temp.Name;
                data.passengerGender = temp.Gender;
                data.ticketClass = temp.ticketClass;
                data.Email = obj.Email;
                data.startingTime = obj.Stime;
                data.endingTime = obj.Etime;
                data.Source = obj.Source;
                data.Destination = obj.Destination;
                data.PNR = pnr;
                context.TicketDetailTbl.Add(data);
             }
            context.SaveChanges();
            return pnr;
            
        }

        
        public int  CancelBookingByEmail(string emailid)
        {
            var res = context.TicketDetailTbl.Where(t => t.PNR == emailid).ToList();
            if(res.Count > 0)
            {
                foreach(var temp in res)
                {
                    int compare = DateTime.Compare(temp.startingTime, DateTime.Now);
                    if (compare > 0)
                    {
                        TimeSpan diff = temp.startingTime - DateTime.Now;
                        if (diff.TotalHours > 24)
                            context.TicketDetailTbl.Remove(temp);
                        else
                            return 0;
                    }
                    else
                        return -1;
                }
                context.SaveChanges();
                return 1;
            }
            return 2;
        }

        public IEnumerable<TicketDetailTbl> GetBookingByEmail(string emailid)
        {
            var res = context.TicketDetailTbl.Where(t => t.Email == emailid).ToList();
            return res;
        }

        public IEnumerable<TicketDetailTbl> GetBookingDetailByPNR(string PNR)
        {
            var res = context.TicketDetailTbl.Where(t => t.PNR == PNR).ToList();                                        
            return res;
        }
    }
}
