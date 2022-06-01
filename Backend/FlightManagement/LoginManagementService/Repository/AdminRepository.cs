using LoginManagementService.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Repository
{
    public class AdminRepository : IadminRepository
    {
        private readonly AppDbContext context;

        public AdminRepository(AppDbContext context)
        {
            this.context = context;
        }
        public string LoginAdmin(string Uname, string Pwd)
        {
            var logindetails = context.adminlogin.Where(u => u.UserName == Uname)
                                        .Select(u => new { u.UserName, u.Password }).FirstOrDefault();
            if (logindetails == null)
                return "User does not exist";
            if (logindetails.UserName == Uname && logindetails.Password == Pwd)
                return "Login Successful";
            else
                return "Username and Password do not match";
        }
    }
}
