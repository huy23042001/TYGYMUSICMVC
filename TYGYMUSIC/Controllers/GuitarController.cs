using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TYGYMUSICBUS;
using TYGYMUSICOBJ;

namespace TYGYMUSIC.Controllers
{
    public class GuitarController : Controller
    {
		GuitarsBUS bus = new GuitarsBUS();
        // GET: Guitar
        public ActionResult Index()
        {
            return View();
        }
		public ActionResult Details()
		{
			return View();
		}
		public JsonResult GetGuitars()
		{
			List<Guitars> guitars = bus.GetAllGuitars();
			return Json(new { guitars }, JsonRequestBehavior.AllowGet);
		}
		public JsonResult Get_Guitars_For_Page(int pageIndex, int pageSize, string guitarName)
		{
			Guitars_List guitars = bus.Get_Guitars_For_Page(pageIndex, pageSize, guitarName);
			return Json(new { guitars }, JsonRequestBehavior.AllowGet);
		}
		public JsonResult GetGuitarDetails(string guitar_id)
		{
			Guitars guitar = bus.Get_Guitar_Details(guitar_id);
			return Json(new { guitar }, JsonRequestBehavior.AllowGet);
		}
	}
}