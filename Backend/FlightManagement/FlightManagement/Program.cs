using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FlightManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            /*IWebHostBuilder builder = new WebHostBuilder();
            builder.ConfigureServices(s =>
            {
                s.AddSingleton(builder);
            });
            builder.UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseStartup<Startup>()
                    .UseUrls("http://localhost:8000");
            var host = builder.Build();
            host.Run();*/
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webbuilder =>
                    {
                        webbuilder.UseStartup<Startup>();
                    })
                    .ConfigureAppConfiguration((hostingcontext, config) =>
                    {
                        config
                        .SetBasePath(hostingcontext.HostingEnvironment.ContentRootPath)
                        .AddJsonFile("Configuration.json", optional: false, reloadOnChange: true);
                    });
                      
                
    }
}
