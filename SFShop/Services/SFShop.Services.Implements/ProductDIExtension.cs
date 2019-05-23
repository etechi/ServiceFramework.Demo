using SF.Sys.Entities.AutoEntityProvider;
using SF.Sys.Services;
using SF.Sys.Entities;
using SF.Sys.IO;
using System.Collections.Generic;
using SF.Sys.Hosting;
using System.Linq;
using SF.Utils;
using System.Threading.Tasks;
using SF.Sys.Linq;
using SF.Sys.Data;
using SF.Sys.BackEndConsole;

namespace SF.Sys.Services
{
    public static class ProductDIExtension

    {

        public static IServiceCollection AddProductServices(
            this IServiceCollection sc,
            string DemoImagePattern = "",
            string TablePrefix = null,
            string ProductFilePath = null,
            string OldDbFilePath = null,
            string ProductImageUrlBase = null
            )
        {
           

            return sc;

        }

    }
}
