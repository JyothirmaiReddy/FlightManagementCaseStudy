using LoginManagementService.Models;
using LoginManagementService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserLoginRepository obj;
        public UserController(IuserLoginRepository obj)
        {
            this.obj = obj;
        }

        // POST api/values
        [HttpPost]
        //[Route("Register")]
        public ActionResult RegisterUser([FromBody] UserLogin user)
        {
            var newuser = obj.GetUser(user.EmailID);
            if (newuser == null)
            {
                obj.RegsiterUser(user);
                return Ok("User Registered Successfully");
            }
            else
            {
                ModelState.AddModelError("Email", "User Already Exists");
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("Login")]
        public string Login(string Uname,string pwd)
        {
            var result = obj.LoginUser(Uname, pwd);
            return result;

        }


    }
}
