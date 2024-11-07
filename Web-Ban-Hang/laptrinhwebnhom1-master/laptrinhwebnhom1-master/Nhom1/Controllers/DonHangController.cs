using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nhom1.Models;
using Newtonsoft.Json;

namespace Nhom1.Controllers
{
    public class DonHangController : Controller
    {
        Nhom1DBContext db = new Nhom1DBContext();

        public ActionResult Index()
        {
            int idSanPham = Convert.ToInt32(Request.QueryString["idSanPham"]);
            SanPham sanPham = db.SanPhamContext.Find(idSanPham);
            
            if (sanPham == null)
                return Redirect("/");
            if (sanPham.SoLuongKho == 0)
                ViewBag.Error = "Hết hàng ời ní ơi!";
            ViewData["SanPham"] = sanPham;

            return View();
        }

        [HttpPost]
        public ActionResult ThemDonHang([System.Web.Http.FromBody]string json)
        {
            dynamic bodyDonHang = JsonConvert.DeserializeObject<dynamic>(json);

            string hoTen = bodyDonHang["HoTen"];
            string soDienThoai = bodyDonHang["SoDienThoai"];
            string email = bodyDonHang["Email"];
            string diaChi = bodyDonHang["DiaChi"];
            int idSanPham = bodyDonHang["IdSanPham"];

            SanPham sanPham = db.SanPhamContext.Find(idSanPham);
            if (sanPham == null)
            {
                return Redirect("/chitietsanpham?idSanPham=" + idSanPham);
            }

            DonHang donHang = new DonHang()
            {
                HoTen = hoTen,
                SoDienThoai = soDienThoai,
                Email = email,
                DiaChi = diaChi,
                TrangThaiDonHang = "Mới",
                NgayThanhToan = null,
                SanPhamId = idSanPham,
                GiaNhapHang = sanPham.GiaNhapHang,
                GiaBan = sanPham.GiaBan,
                GiamGia = sanPham.KhuyenMai != null ? sanPham.KhuyenMai.SoTienGiam : 0,
                SoLuong = 1
            };

            db.DonHangContext.Add(donHang);
            db.SaveChanges();            

            ViewBag.Error = "";
            ViewBag.Success = "Thanh toán thành công !!!";
            ViewData["SanPham"] = sanPham;

            return View("index");
        }
	}
}