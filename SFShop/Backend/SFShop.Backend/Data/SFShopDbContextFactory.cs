


using Microsoft.EntityFrameworkCore.Design;
using SF.Sys.Hosting;
using SF.Sys.Services;

namespace SFShop.Data
{
    public class KDLDbContextFactory : IDesignTimeDbContextFactory<SFShopDbContext>
	{
		IAppInstance Instance { get; } = AppBuilder
			.Init(EnvironmentType.Utils)
			.With((sc,env)=>
			{
				sc.AddMSConfiguration();
			}).Build();

		public SFShopDbContext CreateDbContext(string[] args)
		{
			return Instance.ServiceProvider.Resolve<SFShopDbContext>();
		}
	}


}
