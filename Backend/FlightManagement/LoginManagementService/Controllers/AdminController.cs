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
    public class AdminController : ControllerBase
    {
        private readonly IadminRepository obj;
        public AdminController(IadminRepository obj)
        {
            this.obj = obj;
        }
        [HttpGet]
        [Route("AdminLogin")]
        public string Login(string Uname, string pwd)
        {
            var result = obj.LoginAdmin(Uname, pwd);
            return result;

        }
    }
}
