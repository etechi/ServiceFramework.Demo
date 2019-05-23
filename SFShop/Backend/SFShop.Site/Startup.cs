
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SF.Core.ServiceManagement;
using SF.Sys.AspNetCore;
using SF.Sys.Hosting;
using SF.Sys.Services;
//using IdentityServer4.Stores;
using SF.Sys;

namespace SFShop
{
    public class Startup
    {
        public IHostingEnvironment HostingEnvironment { get; }

        public Startup(IHostingEnvironment HostingEnvironment)
        {
            this.HostingEnvironment = HostingEnvironment;
        }
        public IServiceProvider ConfigureServices(Microsoft.Extensions.DependencyInjection.IServiceCollection services)
        {
            var ins = AppBuilder.Init(HostingEnvironment.DetectEnvType())
                .OnEnvType(
                    t => t != EnvironmentType.Utils,
                    sc =>
                    {
                        sc.AddMSServices(services);

                        sc.AddNetworkService();
                        sc.AddAspNetCoreSupport();
                        sc.AddAspNetCoreServiceInterface();
                        sc.AddFrontSideMvcContentRenderProvider();
                        sc.AddJwtAuthSupports();
                    }
                    )
                .Build();

            return ins.ServiceProvider;
        }

        public void Configure(IApplicationBuilder app)
        {
            app.StartServices();
            app.UseCommonFeatures(routes =>
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    )
                    );
        }

    }
}
