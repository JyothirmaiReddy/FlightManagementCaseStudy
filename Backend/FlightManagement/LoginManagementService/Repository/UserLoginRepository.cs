using LoginManagementService.DbContext;
using LoginManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Repository
{
    public class UserLoginRepository : IuserLoginRepository
    {
        private readonly AppDbContext context;

        public UserLoginRepository(AppDbContext context)
        {
            this.context = context;
        }

        public UserLogin GetUser(string EmailID)
        {
            return context.userlogin.Find(EmailID);
        }

        public string LoginUser(string UName, string Pwd)
        {
            var logindetails = context.userlogin.Where(u => u.UserName == UName)
                                        .Select(u => new { u.UserName, u.Password }).FirstOrDefault();
            if (logindetails == null)
                return "User does not exist";
            if (logindetails.UserName == UName && logindetails.Password == Pwd)
                return "Login Successful";
            else
                return "Username and Password do not match";
           /*if(name.UserName == null)
                re
                        if(name!=null)
            {
                string password = context.userlogin.Where(u => u.UserName == UName)
                                                .Select(u => u.Password).FirstOrDefault();
                
                if (password == Pwd)
                    return "Login Successful";
                else
                    return "UserName and Password do not match";

            }
            return "User does not exist";*/

        }

        public void RegsiterUser(UserLogin userLogin)
        {
            context.userlogin.Add(userLogin);
            context.SaveChanges();
        }
    }
}
