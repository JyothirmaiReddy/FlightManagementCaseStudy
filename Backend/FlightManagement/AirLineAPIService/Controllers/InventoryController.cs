using AirLineAPIService.Models;
using AirLineAPIService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController:ControllerBase
    {
        private readonly IInventoryRepository obj;
        public InventoryController(IInventoryRepository obj)
        {
            this.obj = obj;
        }
        //[Route("AddFlight")]
        [HttpPost]
        public ActionResult AddInventory([FromBody] Inventory inventory)
        {
            var status = obj.AddInventory(inventory);
            if (status)
                return Ok("Inventory Added Successfully");
            else
                ModelState.AddModelError("FlightNo", "Flight Already exists");
                return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("searchflight")]
        public ActionResult<IEnumerable<FlightSearch>> GetFlights(string source,string destination,bool oneway,bool roundtrip)
        {
            var display = obj.GetFlights(source, destination, oneway, roundtrip);
            if (display.Count() > 0)
                return Ok(display);
            return NotFound("No flights exist");

        }
    }
}
