using AirLineAPIService.Models;
using AirLineAPIService.Repository;
using LoginService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles =UserRoles.Admin)]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineRepository airlinerepository;
        public AirlineController(IAirlineRepository airlineRepository)
        {
            this.airlinerepository = airlineRepository;
        }
       
        [HttpGet]
        [Route("SearchAirline")]
        public ActionResult<IEnumerable<Airline>> GetAllAirlines()
        {
            return Ok(airlinerepository.GetAirlines());

        }

     
        [HttpPost]
        [Route("Register")]
        public ActionResult AddAirline([FromBody] Airline airline)
        {
            airlinerepository.AddAirline(airline);
            return Ok();
        }

        [HttpPut]
        [Route("Block")]
        public ActionResult Block(int airlineno)
        {
            var res = airlinerepository.GetAirlinebyNumber(airlineno);
            if(res == null)
            {
                return NotFound("No such Airline exists");
            }
            airlinerepository.BlockAirline(airlineno);
            return Ok();
        }

      

        
        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int airlinenumber)
        {
            var airlinetodelete = airlinerepository.GetAirlinebyNumber(airlinenumber);
            if(airlinetodelete==null)
            {
                return NotFound();
            }
            airlinerepository.DeleteAirline(airlinenumber);
            return Ok();
        }
    }
}
