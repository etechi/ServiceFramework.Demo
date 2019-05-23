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
using SFShop.MSTest.StockApplyTest;
using SFShop.MSTest.StockProvideTest;
using SFShop.Services.PairRecords;
using SFShop.Services.Products;

namespace SFShop.MSTest.SendProductTest
{
    [TestClass]
    public class SendProductTest : TestBase
    {
        [TestMethod]
        public async Task 会员相关发货单列表查询()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
               await sp.GetSendProvides();

            });
        }

        [TestMethod]
        public async Task 会员相关收货单列表查询()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(10,  10, QueryMode.收货人发货单);

            });
        }

        [TestMethod]
        public async Task 供货50申请20()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(20, 50, QueryMode.发货人发货单);

            });
        }
        [TestMethod]
        public async Task 供货30申请50()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(50, 30, QueryMode.发货人发货单);

            });
        }
        [TestMethod]
        public async Task 供货50申请50()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(50, 50, QueryMode.发货人发货单);

            });
        }
        [TestMethod]
        public async Task 供货50申请两个20()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(20, 50, QueryMode.发货人发货单,2);

            });
        }

        [TestMethod]
        public async Task 供货50申请两个30()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(30, 50, QueryMode.发货人发货单, 2);

            });
        }
        [TestMethod]
        public async Task 供货两个20申请50()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(50, 20, QueryMode.发货人发货单, 1,2);

            });
        }
        [TestMethod]
        public async Task 供货两个30申请50()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvides(50, 30, QueryMode.发货人发货单, 1, 2);

            });
        }
        [TestMethod]
        public async Task 会员单个发货单详细内容查询()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetSendProvideInfo();

            });
        }

        [TestMethod]
        public async Task 发货人发货()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.Send();

            });
        }

        [TestMethod]
        public async Task 收货人收货()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.Recv();

            });
        }
    }
}
