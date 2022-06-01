using LoginManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Repository
{
    public interface IuserLoginRepository
    {
        void RegsiterUser(UserLogin userLogin);

        string LoginUser(string UName, string Pwd);

        UserLogin GetUser(string EmailID);
    }
}
