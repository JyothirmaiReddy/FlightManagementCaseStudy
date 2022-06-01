using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Models
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Key]
        [Required]
        [EmailAddress]
        public string EmailID { get; set; }
        
    }
}
