using SFShop.Data;
using SFShop.ServiceSetup;
using SF.Sys;
using SF.Sys.Hosting;
using SF.Sys.Services;

namespace SFShop
{

    public static class AppBuilder 
	{
		public static IAppInstanceBuilder Init(
			EnvironmentType EnvType
			)
		{
			var builder = new AppInstanceBuilder(null,EnvType)
				.With((sc, envType) =>
					sc
					.AddSystemServices(EnvType)
					.AddSqlServerEFCoreDbContext<SFShopDbContext>(EnvType!=EnvironmentType.Utils)
					.AddCommonServices(new CommonServicesSetting
					{
						BackendConsoleName="库存调度管理控制台",
						EnvType=envType,
						StaticResIdent=StaticRes.File
					})
					
					.AddSFShopServices(EnvType)
				)
				;

			return builder;
		}
	}
}