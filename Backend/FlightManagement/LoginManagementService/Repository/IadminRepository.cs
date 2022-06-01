using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginManagementService.Repository
{
    public interface IadminRepository
    {
        string LoginAdmin(string Uname, string Pwd);
    }
}
