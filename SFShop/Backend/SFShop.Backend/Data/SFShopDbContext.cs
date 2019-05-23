

using Microsoft.EntityFrameworkCore;

namespace SFShop.Data
{
	public class SFShopDbContext : DbContext
	{
		public SFShopDbContext(DbContextOptions<SFShopDbContext> options)
			: base(options)
		{
		}


		public override void Dispose()
		{
			base.Dispose();
		}
	}

}
 