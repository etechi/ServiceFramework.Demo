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
using SFShop.Services.PairRecords.Models;
using SFShop.Services.PairRecords.Front;

namespace SFShop.MSTest.ProductTest
{
   public static class ProductInfosTestExtension
    {
        public static async Task<long> GetProductInfos(this IServiceProvider sp)
        {
            var ds = sp.Resolve<IProductService>();
            var pros = await ds.GetProductInfos();
            Assert.IsTrue(pros != null);
            Assert.IsTrue(pros.Items != null);
            Assert.IsTrue(pros.Items.Count() > 0);
            Assert.IsTrue(pros.Items.FirstOrDefault().ProductName.HasContent());
            Assert.IsTrue(pros.Items.FirstOrDefault().Unit.HasContent());
            Assert.IsTrue(pros.Items.FirstOrDefault().ProductId > 0);
            return pros.Items.FirstOrDefault().ProductId;
        }
        public static async Task CreateNewPairRecord(this IServiceProvider sp)
        {
            
            var ds = sp.Resolve<IPairRecordService>();
            await ds.CreateNewPairRecord();
           
        }
    }
}
