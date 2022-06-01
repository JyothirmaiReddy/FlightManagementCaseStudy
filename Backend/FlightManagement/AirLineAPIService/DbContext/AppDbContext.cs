using AirLineAPIService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirLineAPIService.DbContext
{
  
        public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
