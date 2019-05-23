
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using SF.Sys.Settings;
using SF.Sys.AspNetCore;

namespace SFShop.Site.Controllers
{
	public class HomeController : Controller
	{
	
		public HomeController()
        {
        }

        public ActionResult Index()
		{
			ViewBag.ShowCatMenu = true;
			//await this.LoadUIPageBlocks("首页");

			return View();
		}
	}
}
