using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Models
{
    public class AdminLogin
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
