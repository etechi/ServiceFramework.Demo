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
using SFShop.Services.PairRecords;

namespace SFShop.MSTest.ProductTest
{
    [TestClass]
    public class ProductTest : TestBase
    {
        [TestMethod]
        public async Task 产品信息查询()
        {
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.GetProductInfos();
               
            });
        }
        [TestMethod]
        public async Task 配对测试()
        {
            
            await NewServiceScope().Use(async (IServiceProvider sp) =>
            {
                await sp.CreateNewPairRecord();

            });
        }
    }
}
