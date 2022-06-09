using BookingManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Repository
{
    public interface IbookingRepository
    {
        string AddBooking(BookFlightTbl obj);
        IEnumerable<TicketDetailTbl> GetBookingByEmail(string emailid);
        int  CancelBookingByEmail(string emailid);
        IEnumerable<TicketDetailTbl> GetBookingDetailByPNR(string PNR);
    }
}
