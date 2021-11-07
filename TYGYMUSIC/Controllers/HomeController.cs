using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TYGYMUSICBUS;
using TYGYMUSICOBJ;

namespace TYGYMUSIC.Controllers
{
	public class HomeController : Controller
	{
		GuitarsBUS bus = new GuitarsBUS();
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult IndexPage()
		{
			return View();
		}
		[HttpGet]
		public JsonResult GetGuitars()
		{
			List<Guitars> guitars = bus.GetAllGuitars();
			return Json(new { guitars }, JsonRequestBehavior.AllowGet);
		}
		[HttpGet]
		public JsonResult Get_Guitars_For_Page(int pageIndex, int pageSize, string guitarName)
		{
			Guitars_List guitars = bus.Get_Guitars_For_Page(pageIndex, pageSize, guitarName);
			return Json(new { guitars }, JsonRequestBehavior.AllowGet);
		}
	}
}