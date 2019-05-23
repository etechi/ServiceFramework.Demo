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
using System.Diagnostics;

namespace SFShop.MSTest.StockApplyTest
{
    public static class StockApplysTestExtension
    {
        public static async Task<decimal> GetStockApplys(this IServiceProvider sp)
        {
            var ds = sp.Resolve<IStockApplyService>();
            var applys = await ds.QueryMemberStockApplyInfo(new MemberStockApplyQueryArg { });
            Assert.IsTrue(applys != null);
            Assert.IsTrue(applys.Items != null);
            Assert.IsTrue(applys.Items.Count() > 0);
            Assert.IsTrue(applys.Items.FirstOrDefault().ProductName.HasContent());
            Assert.IsTrue(applys.Items.FirstOrDefault().ApplyNum>0);
            Assert.IsTrue(applys.Items.FirstOrDefault().ProductUnit.HasContent());
            Assert.IsTrue(applys.Items.FirstOrDefault().UnPairNum>0);
            return applys.Items.FirstOrDefault().ApplyNum;
        }
        public static async Task<decimal> GetMemberStockApplyMaxNum(this IServiceProvider sp)
        {
            var ds = sp.Resolve<IStockApplyService>();
            var StockApplyMaxNum = await ds.QueryMemberStockApplyMaxNum(10);
            Assert.IsTrue(StockApplyMaxNum != null);
            Assert.IsTrue(StockApplyMaxNum.ApplyNum >=0);
            Assert.IsTrue(StockApplyMaxNum.ProductId > 0);
            return StockApplyMaxNum.ApplyNum;
        }
        public static async Task<long> AddStockApply(this IServiceProvider sp,long productId=1,decimal applyNum=10)
        {
            var ds = sp.Resolve<IStockApplyService>();
            var ApplyInfo = new MemberStockApplyArg { ApplyNum = applyNum, ProductId = productId };
            var applyId = await ds.AddStockApply( ApplyInfo);
            var applys = await ds.QueryMemberStockApplyInfo(new MemberStockApplyQueryArg { });
            Assert.IsTrue(applyId.Id > 0);
            Assert.IsTrue(applys.Items.FirstOrDefault().ApplyNum == ApplyInfo.ApplyNum);
            Assert.IsTrue(applys.Items.FirstOrDefault().ProductId == ApplyInfo.ProductId);
            return applyId.Id;
        }
        public static async Task<CanApplyProductInfo[]> GetStockApplyProducts(this IServiceProvider sp)
        {
            var ds = sp.Resolve<IStockApplyService>();
            var applys = await ds.QueryCanApplyProducts();
            Assert.IsTrue(applys.Length > 0);
            return applys;
        }
    }
}
