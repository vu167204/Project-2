using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom1.Models;
using System.Data.Entity.Migrations;

namespace Nhom1.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        private Nhom1DBContext db = new Nhom1DBContext();

        public ActionResult Index()
        {
            var queryIdSanPham = Request.QueryString["IdSanPham"];
            int IdSanPham;

            ViewData["SanPham"] = null;

            if (queryIdSanPham != null && queryIdSanPham.Trim() != "" && int.TryParse(queryIdSanPham, out IdSanPham))
            {   
                SanPham sanPham = db.SanPhamContext.Where(sp => sp.SanPhamId == IdSanPham).First();
                if (sanPham != null)
                {
                    sanPham.LuotXem = sanPham.LuotXem + 1;
                    db.SanPhamContext.AddOrUpdate(sanPham);
                    db.SaveChanges();
                    ViewData["SanPham"] = sanPham;
                    return View();
                }
            }
            return Redirect("/");
        }
	}
}