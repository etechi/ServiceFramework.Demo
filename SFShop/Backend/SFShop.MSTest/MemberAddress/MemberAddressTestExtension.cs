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
   public static class ProductInfosTestExtension
    {
        public static async Task setAddressInfo(this IServiceProvider sp)
        {
            var ds = sp.Resolve<IMemberAddressService>();
            var memInfo = new MemberAddressInfo()
            {
                MemberAddress = "发货地址" + Strings.NumberAndLowerUpperChars.Random(4),
                MemberName = "发货人" + Strings.NumberAndLowerUpperChars.Random(4),
                MemberPhoneNum = "1888888" + Strings.Numbers.Random(4)
            };
            await ds.SetMemberAddressInfo(memInfo);
            var oldName = await ds.GetMemberAddressInfo();
            Assert.AreEqual(memInfo.MemberAddress, oldName.MemberAddress);
            Assert.AreEqual(memInfo.MemberName, oldName.MemberName);
            Assert.AreEqual(memInfo.MemberPhoneNum, oldName.MemberPhoneNum);
        }
    }
}
