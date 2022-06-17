using BookingManagementService.Models;
using BookingManagementService.Repository;
using LoginService.Models;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =UserRoles.User)]
    public class BookingController : ControllerBase
    {
        private readonly IbookingRepository bookingrepository;
        private readonly IBus _bus;
        public BookingController(IbookingRepository bookingrepository, IBus bus)
        {
            this.bookingrepository = bookingrepository;
            _bus = bus;
        }
        [HttpPost]
        [Route("Book")]
        public async void AddBooking([FromBody] BookFlightTbl bookflight)
        {
            bookingrepository.AddBooking(bookflight);
            int businessClassSeats = bookflight.passengers.Where(p => p.ticketClass.ToLower() == "business").Count();
            int nonbusinessClassSeats = bookflight.passengers.Where(p => p.ticketClass.ToLower() == "nonbusiness").Count();
            Uri uri = new Uri("rabbitmq://localhost/ticketClassQueue");
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(new RMQData
            {
                businessSeats = businessClassSeats,
                nonbusinessSeats = nonbusinessClassSeats,
                flightNumber = bookflight.FlightNo
            });
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
