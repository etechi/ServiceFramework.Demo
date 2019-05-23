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
using SFShop.Services.Products.Front;
using SFShop.MSTest.MemberAddress;

namespace SFShop.MSTest.StockProvideTest
{
    [TestClass]
    public class StockProvideTest : TestBase
    {
        [TestMethod]
        public async Task 会员库存提供列表查询()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                    await sp.setAddressInfo();
                    await sp.AddStockProvide();
                    await sp.GetStockProvides();

                    return 0;
                });
                
            });
        }
       
        [TestMethod]
        public async Task 发布库存提供()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                    await sp.setAddressInfo();
                    await sp.AddStockProvide();

                    return 0;
                });
                
            });
        }
    }
}
