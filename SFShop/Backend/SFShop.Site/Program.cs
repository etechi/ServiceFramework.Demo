
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SF.Sys.ServiceFeatures;
using SF.Sys.Services;

namespace SFShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length>0&&args[0] == "init-services")
            {
                var sfcs = BuildWebHost(args).Services.Resolve<IServiceFeatureControlService>();
                sfcs.Init("service");
                return;
            }

            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
			//.UseUrls("http://localhost:80")
            .UseStartup<Startup>()
            .Build();
    }
}
