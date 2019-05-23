using System;
using System.Threading.Tasks;
using SF.Sys.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SFShop.Services.MemberAddresss;
using SF.Sys.Linq;
using SF.Sys;
using SF.Common.UnitTest;
using SFShop.UT;
using SFShop.Services.MemberAddresss.Front;

namespace SFShop.MSTest.MemberAddress
{
    [TestClass]
    public class MemberAddressTest: TestBase
    {
        [TestMethod]
        public async Task 会员地址新建()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                   await sp.setAddressInfo();
                    return 0;
                });
            });
        }

        [TestMethod]
        public async Task 会员地址修改()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {

                    await sp.setAddressInfo();
                    await sp.setAddressInfo();

                    return 0;
                });
            });
        }

    }
}
