using LoginService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        public string Index()
        {
            return "Hi! This is Test";
        }
    }
}
