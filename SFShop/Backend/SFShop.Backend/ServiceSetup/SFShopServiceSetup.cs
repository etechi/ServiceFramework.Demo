
using SF.Sys.Hosting;
using SF.Sys.Services;

namespace SFShop.ServiceSetup
{
    public static class SFShopServiceSetup
	{
		public static IServiceCollection AddSFShopServices(this IServiceCollection Services, EnvironmentType EnvType)
		{

            return Services;
		}
		
	}


}
