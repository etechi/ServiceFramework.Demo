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
using SFShop.Services.EnumType;
using System.Diagnostics;
using SFShop.MSTest.StockApplyTest;
using SFShop.MSTest.StockProvideTest;
using SFShop.Services.PairRecords;
using SFShop.Services.Products;
using SFShop.MSTest.MemberAddress;
using SF.Sys.Entities;

namespace SFShop.MSTest.SendProductTest
{
    public static class SendProductsTestExtension
    {
        public static async Task<long> GetSendProvides(this IServiceProvider sp, decimal applyNum=10, decimal provideNum=10, Services.Products.Front.QueryMode qMode= Services.Products.Front.QueryMode.发货人发货单,int appDouble = 1,int proDouble=1)
        {
            var ds = sp.Resolve<ISendProductService>();
            var sendproducts = await CreateSendProduct(sp, applyNum, provideNum,qMode,appDouble,proDouble);
            Assert.IsTrue(sendproducts != null);
            Assert.IsTrue(sendproducts.Items != null);
            Assert.IsTrue(sendproducts.Items.Count() > 0);
            Assert.IsTrue(sendproducts.Items.FirstOrDefault().ProductName.HasContent());
            Assert.IsTrue(sendproducts.Items.FirstOrDefault().SendNum>0);
            Assert.IsTrue(sendproducts.Items.FirstOrDefault().ProductUnit.HasContent());
            return sendproducts.Items.FirstOrDefault().SendId;
        }
        public static async Task<decimal> GetSendProvideInfo(this IServiceProvider sp)
        {
            var ds = sp.Resolve<ISendProductService>();
            var sendid = await sp.GetSendProvides();
            var sendproductInfo = await ds.GetSendProductInfo(sendid);
            Assert.IsTrue(sendproductInfo != null);
            Assert.IsTrue(sendproductInfo.ProductName.HasContent());
            Assert.IsTrue(sendproductInfo.SendNum > 0);
            Assert.IsTrue(sendproductInfo.ProductUnit.HasContent());
            return sendproductInfo.SendNum;
        }

        public static async Task<long> Send(this IServiceProvider sp)
        {
            var ds = sp.Resolve<ISendProductService>();
            var sendid =await sp.GetSendProvides();
            var sendarg = new SendArg { SendId= sendid, LogisticsImgId="ms-qwqeqweqweqwe",LogisticsNum="123456789"};
            await ds.Send(sendarg);
            var sendproductInfo = await ds.GetSendProductInfo(sendid);
            Assert.IsTrue(sendproductInfo != null);
            Assert.IsTrue(sendproductInfo.ProductName.HasContent());
            Assert.IsTrue(sendproductInfo.SendNum > 0);
            Assert.IsTrue(sendproductInfo.ProductUnit.HasContent());
            return sendproductInfo.SendId;
        }
        public static async Task<long> Recv(this IServiceProvider sp)
        {
            var ds = sp.Resolve<ISendProductService>();
            ObjectKey<long> product = await CreateProduct(sp);
            (long applyId, UserInfo user) app = await CreateNewApply(sp, 10, product);
           
            (long provideId, UserInfo user) pro = await CreateNewProvide(sp, 10, product);
          
            await CreateNewPairRecord(sp);
            var sendids = new QueryResult<SendProductItem>();
            await sp.UserSignin(pro.user.Account, pro.user.Password);
            await sp.WithScope(async isp =>
            {
                sendids = await isp.Resolve<ISendProductService>().QuerySendProductInfo(new MemberSendProductQueryArg {QueryMode=Services.Products.Front.QueryMode.发货人发货单  });
            });
          
            var sendarg = new SendArg { SendId = sendids.Items.FirstOrDefault().SendId, LogisticsImgId = "ms-qwqeqweqweqwe", LogisticsNum = "123456789" };
            await ds.Send(sendarg);

            await sp.UserSignin(app.user.Account, app.user.Password);
            await ds.Recv(sendids.Items.FirstOrDefault().SendId);
            var sendproductInfo = await ds.GetSendProductInfo(sendids.Items.FirstOrDefault().SendId);
            Assert.IsTrue(sendproductInfo != null);
            Assert.IsTrue(sendproductInfo.ProductName.HasContent());
            Assert.IsTrue(sendproductInfo.SendNum > 0);
            Assert.IsTrue(sendproductInfo.ProductUnit.HasContent());
            return sendproductInfo.SendId;
        }
        private static async Task<QueryResult<SendProductItem>> CreateSendProduct(IServiceProvider sp, decimal applyNum, decimal provideNum, Services.Products.Front.QueryMode qMode,int appDouble = 1, int proDouble = 1)
        {
            ObjectKey<long> product = await CreateProduct(sp);
            (long applyId, UserInfo user) app = await CreateNewApply(sp, applyNum, product);
            if(appDouble==2)
            {
                (long applyId, UserInfo user) appNew = await CreateNewApply(sp, applyNum, product);
            }
            (long provideId, UserInfo user) pro = await CreateNewProvide(sp, provideNum, product);
            if (proDouble == 2)
            {
                (long provideId, UserInfo user) proNew = await CreateNewProvide(sp, provideNum, product);
            }
            await CreateNewPairRecord(sp);
            var sendids = new QueryResult<SendProductItem>();
            await sp.WithScope(async isp =>
            {
                if(qMode== Services.Products.Front.QueryMode.发货人发货单)
                    await isp.UserSignin(pro.user.Account, pro.user.Password);
                else
                    await isp.UserSignin(app.user.Account, app.user.Password);
                //Debugger.Launch();
                sendids = await isp.Resolve<ISendProductService>().QuerySendProductInfo(new MemberSendProductQueryArg { QueryMode = qMode });
            });
            return sendids;
        }

        private static async Task CreateNewPairRecord(IServiceProvider sp)
        {
            await sp.WithScope(async isp =>
            {
                await isp.UserSignin("系统管理员1", "system");
                await isp.Resolve<IPairRecordManager>().CreateAsync(new Services.PairRecords.Models.PairRecord
                {
                    Name = "rec1"
                });
            });
        }

        private static async Task<(long provideId, UserInfo user)> CreateNewProvide(IServiceProvider sp, decimal provideNum, ObjectKey<long> product)
        {
            return await sp.WithScope(async isp =>
            {
                var user = await isp.UserCreate();
                await isp.setAddressInfo();
                var provideId = await isp.AddStockProvide(product.Id, provideNum);
                return (provideId, user);
            });
        }

        private static async Task<(long applyId, UserInfo user)> CreateNewApply(IServiceProvider sp, decimal applyNum, ObjectKey<long> product)
        {
            return await sp.WithScope(async isp =>
            {
                var user = await isp.UserCreate();
                await isp.setAddressInfo();
                var applyId = await isp.AddStockApply(product.Id, applyNum);
                return (applyId, user);
            });
        }

        private static async Task<ObjectKey<long>> CreateProduct(IServiceProvider sp)
        {
            return await sp.WithScope(async isp =>
            {
                await isp.UserSignin("系统管理员1", "system");
                return await isp.Resolve<IProductManager>().CreateAsync(new Services.Products.Models.Product
                {
                    Name = "rec1",
                    Unit = "条"
                });
            });
        }
    }
}
