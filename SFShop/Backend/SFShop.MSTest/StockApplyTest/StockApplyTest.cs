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
using SFShop.MSTest.StockProvideTest;

namespace SFShop.MSTest.StockApplyTest
{
    [TestClass]
    public class StockApplyTest : TestBase
    {
        [TestMethod]
        public async Task 会员库存申请列表查询()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                    
                    await sp.setAddressInfo();
                    await sp.AddStockApply();
                    await sp.GetStockApplys();

                    return 0;
                });
                
            });
        }
        [TestMethod]
        public async Task 获取当前会员最大申请数量()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                    await sp.setAddressInfo();
                    await sp.AddStockApply();
                    await sp.GetMemberStockApplyMaxNum();

                    return 0;
                });
                
            });
        }
        [TestMethod]
        public async Task 发布库存申请()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                    await sp.setAddressInfo();
                    await sp.AddStockApply();

                    return 0;
                });
                
            });
        }

        [TestMethod]
        public async Task 获取会员可申请产品列表()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                return await sp.WithNewUser(async user =>
                {
                    await sp.setAddressInfo();
                    await sp.AddStockApply(1,5);
                    await sp.AddStockProvide();
                    await sp.GetStockApplyProducts();
                    return 0;
                });

            });
        }
    }
}
