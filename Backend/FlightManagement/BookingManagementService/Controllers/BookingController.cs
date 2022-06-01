using BookingManagementService.Models;
using BookingManagementService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IbookingRepository bookingrepository;
        public BookingController(IbookingRepository bookingrepository)
        {
            this.bookingrepository = bookingrepository;
        }
        [HttpPost]
        //[Route("Book")]
        public void AddBooking([FromBody] BookFlightTbl bookflight)
        {
            bookingrepository.AddBooking(bookflight);
        }
        [HttpDelete("{Email}")]
        //[Route("CancelBooking")]
        public void CancelBookingByEmailID(string Email)
        {
            bookingrepository.CancelBookingByEmail(Email);
        }
        [HttpGet("{email}")]
        //[Route("GetBookingbyEmail")]
        public ActionResult<IEnumerable<TicketDetailTbl>> GetBookingByEmailID(string email)
        {
            var data = bookingrepository.GetBookingByEmail(email);
            if (data.Count() > 0)
                return Ok(data);
            return NotFound("No Booking exists");

        }

        [HttpGet("{PNR}")]
        //[Route("GetBookingbyPNR")]
        public ActionResult<IEnumerable<TicketDetailTbl>> GetBookingByPNR(string PNR)
        {
            var data = bookingrepository.GetBookingDetailByPNR(PNR);
            if (data.Count() > 0)
                return Ok(data);
            return NotFound("No Booking exists");

        }


    }
}
