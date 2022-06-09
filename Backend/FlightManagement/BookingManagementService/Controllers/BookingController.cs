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
        [HttpDelete()]
        [Route("CancelBooking")]
        public ActionResult CancelBookingByEmailID(string Email)
        {
            var res = bookingrepository.CancelBookingByEmail(Email);
            if (res == 1)
                return Ok("Booking Cancelled");
            if (res == 2)
                return NotFound("No booking exists to cancel");
            if (res == -1)
                return BadRequest("Can't Cancel Outdated booking");
            if(res ==0)
                ModelState.AddModelError("Booking", "Can't Cancel booking when there is less than 24 hrs time for the flight");
                return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("GetBookingbyEmail")]
        public ActionResult<IEnumerable<TicketDetailTbl>> GetBookingByEmailID(string email)
        {
            var data = bookingrepository.GetBookingByEmail(email);
            if (data.Count() > 0)
                return Ok(data);
            return NotFound("No Booking exists");

        }

        [HttpGet]
        [Route("GetBookingbyPNR")]
        public ActionResult<IEnumerable<TicketDetailTbl>> GetBookingByPNR(string PNR)
        {
            var data = bookingrepository.GetBookingDetailByPNR(PNR);
            if (data.Count() > 0)
                return Ok(data);
            return NotFound("No Booking exists");

        }


    }
}
