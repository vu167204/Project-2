using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom1.Repositories;

namespace Nhom1.Controllers
{
    public class MayTinhBangController : Controller
    {
        public ActionResult Index()
        {
            ViewData["ListSanPham"] = SanPhamRepo.LoadListSanPham("Máy tính bảng");

            return View();
        }
    }
}