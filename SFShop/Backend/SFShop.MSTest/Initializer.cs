
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SF.Sys.Services;
using SF.Sys.ServiceFeatures;
using SF.Sys.Tests;
using SF.Sys.UnitTest;
using System.Collections.Generic;

namespace SFShop.UT
{
    [TestClass]
    public class EnvInitializer : TestBase
    {

        [TestMethod]
        public async Task InitServices()
        {
            await NewServiceScope().Use(async (sp, ct) =>
            {
                await sp.InitServices("service");
            }
                );
        }
        [TestMethod]
        public async Task ����_����()
        {
            await NewServiceScope().Use(async (sp, ct) =>
            {
                await sp.InitServices("import_disease");
            }
            );
        }
        [TestMethod]
        public async Task ����_ҩƷ�����ݿ�()
        {
            await NewServiceScope().Use(async (sp, ct) =>
            {
                await sp.InitServices("import_pharmacon_db");
            }
            );
        }
        [TestMethod]
        public async Task ����_ҩƷ�ļ�()
        {
            await NewServiceScope().Use(async (sp, ct) =>
            {
                await sp.InitServices("import_pharmacon_file");
            }
            );
        }
        [TestMethod]
        public async Task InitData()
        {
            await NewServiceScope().Use(async (sp, ct) =>
            {
                await sp.InitServices(
                    "data",
                    new Dictionary<string, string> {
                        { "host", "localhost:5000" },
                        { "ext-ident-postfix", "00" },
                    });
            }
            );
        }

        [TestMethod]
        public async Task AutoEntityTest()
        {
            await NewServiceScope().Use(async (sp, ct) =>
            {
                var tcp = sp.Resolve<ITestCaseProvider>();
                var cases = tcp.GetTestCases();
                foreach (var c in cases)
                    await tcp.Execute(c);
            });
        }
    }


}
