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
namespace SFShop.MSTest.StockProvideTest
{
    public static class StockProvidesTestExtension
    {
        public static async Task<decimal> GetStockProvides(this IServiceProvider sp)
        {
            var ds = sp.Resolve<IStockProvideService>();
            var provides = await ds.QueryMemberStockProvideInfo(new MemberStockProvideQueryArg { });
            Assert.IsTrue(provides != null);
            Assert.IsTrue(provides.Items != null);
            Assert.IsTrue(provides.Items.Count() > 0);
            Assert.IsTrue(provides.Items.FirstOrDefault().ProductName.HasContent());
            Assert.IsTrue(provides.Items.FirstOrDefault().ProvideNum>0);
            Assert.IsTrue(provides.Items.FirstOrDefault().ProductUnit.HasContent());
            Assert.IsTrue(provides.Items.FirstOrDefault().UnPairNum>0);
            return provides.Items.FirstOrDefault().ProvideNum;
        }
       
        public static async Task<long> AddStockProvide(this IServiceProvider sp,long productid=1,decimal ProvideNum=10)
        {
            var ds = sp.Resolve<IStockProvideService>();
            var ProvideInfo = new MemberStockProvideArg { ProvideNum = ProvideNum, ProductId = productid, Fee=10 };
            var ProvideId = await ds.AddStockProvide(ProvideInfo);
            var provides = await ds.QueryMemberStockProvideInfo(new MemberStockProvideQueryArg { });
            Assert.IsTrue(ProvideId.Id > 0);
            Assert.IsTrue(provides.Items.FirstOrDefault().ProvideNum == ProvideInfo.ProvideNum);
            Assert.IsTrue(provides.Items.FirstOrDefault().ProductId == ProvideInfo.ProductId);
            Assert.IsTrue(provides.Items.FirstOrDefault().Fee == ProvideInfo.Fee);
            return ProvideId.Id;
        }
    }
}
