
using SF.Sys.Hosting;
using SF.Sys.NetworkService;
using System;
using SF.Sys.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SF.Sys.Auth;
using SF.Sys.TimeServices;

namespace SFShop.UT
{
    public static class TestAppBuilder
    {
        public static IAppInstanceBuilder Instance { get; } =
            AppBuilder.Init(EnvironmentType.Development).
                With(sc =>
                {
                    var rootPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\SFShop.Site\\");
                    var binPath = System.IO.Path.Combine(rootPath, "bin\\Debug\\netcoreapp2.0\\");
                    sc.AddTestFilePathStructure(
                        binPath,
                        rootPath
                        );
                    sc.AddMSConfiguration();
                    sc.AddSingleton(new Moq.Mock<IInvokeContext>().Object);
                    sc.AddSingleton(new Moq.Mock<IAccessTokenGenerator>().Object);
                    sc.AddSingleton(new Moq.Mock<IAccessTokenValidator>().Object);
                    sc.AddSingleton(new Moq.Mock<IUploadedFileCollection>().Object);
                    sc.AddNetworkService();
                    sc.AddLocalClientService();

                });
    }

}
