using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom1.Models;
using BCrypt.Net;
using System.Web.Security;
using Nhom1.Helpers;

namespace Nhom1.Controllers
{
    public class FormDangNhap
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class DangNhapController : Controller
    {
        private Nhom1DBContext context = new Nhom1DBContext();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormDangNhap form)
        {
            if (AppHelper.IsEmptyString(form.Username) || AppHelper.IsEmptyString(form.Username))
            {
                ViewBag.Error = "Vui lòng không bỏ trống 'Tài khoản' và 'Mật khẩu'!";
                return View();
            }

            try
            {
                IQueryable<TaiKhoan> taiKhoanQuery = context.TaiKhoanContext.Where(tk => tk.Username == form.Username);

                if (taiKhoanQuery == null) {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
                    return View();
                }

                TaiKhoan taiKhoan = taiKhoanQuery.First();

                if (taiKhoan == null || !BCrypt.Net.BCrypt.Verify(form.Password, taiKhoan.Hash))
                {
                    ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
                    return View();
                }

                FormsAuthentication.SetAuthCookie(taiKhoan.Username, true);

                return Redirect("/admin");
            }
            catch
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
                return View();
            }
        }
	}
}