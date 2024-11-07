using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nhom1.Controllers
{
    public class DienThoaiController : Controller
    {
        //
        // GET: /DienThoai/
        public ActionResult Index()
        {
            var concho = 20;
            ViewData["concho"] = concho;
            return View(concho);
        }
	}
}