using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginManagementService.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserLogin> userlogin { get; set; }
        public DbSet<AdminLogin> adminlogin { get; set; }
    }
}
