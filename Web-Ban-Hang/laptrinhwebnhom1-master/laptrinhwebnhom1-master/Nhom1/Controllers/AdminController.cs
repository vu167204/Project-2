using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BCrypt.Net;
using Nhom1.Helpers;
using Nhom1.Models;
using System.Data.Entity.Migrations;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace Nhom1.Controllers
{
    public class AdminController : Controller
    {
        Nhom1DBContext db = new Nhom1DBContext();

        [Authorize]
        public ActionResult Index()
        {
            int year, month;

            year = DateTime.Now.Year;
            month = DateTime.Now.Month;

            if (Request.QueryString["year"] != null)
                year = Convert.ToInt32(Request.QueryString["year"]);
            year = Math.Min(DateTime.Now.Year, Math.Max(2000, year));

            if (Request.QueryString["month"] != null)
                month = Convert.ToInt32(Request.QueryString["month"]);
            month = Math.Min(12, Math.Max(1, month));

            double loiNhuanThang = ThongKeloiNhuanTheoThang(year, month);
            double loiNhuanNam = ThongKeloiNhuanTheoNam(year);
            int soDonHangThang = ThongKeDonHangDaThanhToanTheoThang(year, month);
            int soDonHangNam = ThongKeDonHangDaThanhToanTheoNam(year);

            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.loiNhuanThang = loiNhuanThang;
            ViewBag.loiNhuanNam = loiNhuanNam;
            ViewBag.SoDonHangThang = soDonHangThang;
            ViewBag.SoDonHangNam = soDonHangNam;
            ViewBag.SoDonHangMoi = ThongKeDonHangMoi();

            return View();
        }

        private double ThongKeloiNhuanTheoThang(int year, int month)
        {
            var listDonHang = db.DonHangContext
                                .Where(dh => dh.TrangThaiDonHang == "Đã thanh toán")
                                .Where(dh => ((DateTime)dh.NgayThanhToan).Month == month && ((DateTime)dh.NgayThanhToan).Year == year);

            double loiNhuan = 0;

            if (listDonHang.Count() > 0)
                loiNhuan = listDonHang.Sum(dh => dh.GiaBan - dh.GiamGia - dh.GiaNhapHang);

            return loiNhuan;
        }

        private double ThongKeloiNhuanTheoNam(int year)
        {
            var listDonHang = db.DonHangContext
                                .Where(dh => dh.TrangThaiDonHang == "Đã thanh toán")
                                .Where(dh => ((DateTime)dh.NgayThanhToan).Year == year);
            double loiNhuan = 0;

            if (listDonHang != null)
                loiNhuan = listDonHang.Sum(dh => dh.GiaBan - dh.GiamGia - dh.GiaNhapHang);

            return loiNhuan;
        }

        private int ThongKeDonHangDaThanhToanTheoThang(int year, int month)
        {
            var listDonHang = db.DonHangContext
                                .Where(dh => dh.TrangThaiDonHang == "Đã thanh toán")
                                .Where(dh => ((DateTime)dh.NgayThanhToan).Month == month && ((DateTime)dh.NgayThanhToan).Year == year);
            int soLuong = 0;

            if (listDonHang != null)
                soLuong = listDonHang.Count();

            return soLuong;
        }

        private int ThongKeDonHangDaThanhToanTheoNam(int year)
        {
            var listDonHang = db.DonHangContext
                                .Where(dh => dh.TrangThaiDonHang == "Đã thanh toán")
                                .Where(dh => ((DateTime)dh.NgayThanhToan).Year == year);
            int soLuong = 0;

            if (listDonHang != null)
                soLuong = listDonHang.Count();

            return soLuong;
        }

        private int ThongKeDonHangMoi()
        {
            var listDonHang = db.DonHangContext
                                .Where(dh => dh.TrangThaiDonHang == "Mới");
            int soLuong = 0;

            if (listDonHang != null)
                soLuong = listDonHang.Count();

            return soLuong;
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetDuLieuTheoNam(int year)
        {
            List<int> donHang = new List<int>();
            List<double> loiNhuan = new List<double>();

            for (int month = 1; month <= 12; month++)
            {
                int soDonThang = ThongKeDonHangDaThanhToanTheoThang(year, month);
                double loiNhuanThang = ThongKeloiNhuanTheoThang(year, month);

                donHang.Add(soDonThang);
                loiNhuan.Add(loiNhuanThang);
            }

            return Json(new {DonHang = donHang, LoiNhuan = loiNhuan}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public ActionResult DoiMatKhau()
        {
            ViewBag.Error = null;
            ViewBag.SoDonHangMoi = ThongKeDonHangMoi();
            return View("DoiMatKhau");
        }

        [HttpPost]
        public ActionResult DoiMatKhau(FormDoiMatKhau form)
        {
            string username = User.Identity.Name;

            if (AppHelper.IsEmptyString(form.MatKhau) || AppHelper.IsEmptyString(form.MatKhauMoi) || AppHelper.IsEmptyString(form.NhapLaiMatKhauMoi))
            {
                ViewBag.Error = "Vui lòng điền đầy đủ thông tin";
                return View("DoiMatKhau");
            }

            TaiKhoan taiKhoan = db.TaiKhoanContext.Where(tk => tk.Username == username).First();

            if (taiKhoan == null)
            {
                FormsAuthentication.SignOut();
                return Redirect("/");
            }

            if (!BCrypt.Net.BCrypt.Verify(form.MatKhau, taiKhoan.Hash))
            {
                ViewBag.Error = "Mật khẩu không chính xác";
                return View("DoiMatKhau");
            }

            if (form.MatKhauMoi != form.NhapLaiMatKhauMoi)
            {
                ViewBag.Error = "Mật khẩu mới không khớp";
                return View("DoiMatKhau");
            }

            taiKhoan.Hash = BCrypt.Net.BCrypt.HashPassword(form.MatKhauMoi, 10);

            db.TaiKhoanContext.AddOrUpdate(taiKhoan);
            db.SaveChanges();

            return Redirect("/admin");
        }

        [HttpGet]
        [Authorize]
        public ActionResult QuanLySanPham()
        {
            ViewBag.ListSanPham = db.SanPhamContext.OrderByDescending(sp => sp.LuotXem).OrderBy(sp => sp.SanPhamId).ToList();
            ViewBag.SoDonHangMoi = ThongKeDonHangMoi();
            return View("QuanLySanPham");
        }

        [HttpGet]
        [Authorize]
        public ActionResult QuanLyDonHang()
        {
            var listDonHangMoi = db.DonHangContext.OrderByDescending(dh => dh.UpdatedAt).OrderByDescending(dh => dh.DonHangId).Where(dh => dh.TrangThaiDonHang == "Mới").ToList();
            var listDonHangDangGiao = db.DonHangContext.OrderByDescending(dh => dh.UpdatedAt).OrderByDescending(dh => dh.DonHangId).Where(dh => dh.TrangThaiDonHang == "Đang giao hàng").ToList();
            var listDonHangDaThanhToan = db.DonHangContext.OrderByDescending(dh => dh.UpdatedAt).OrderByDescending(dh => dh.DonHangId).Where(dh => dh.TrangThaiDonHang == "Đã thanh toán").ToList();

            ViewData["DonHangMoi"] = listDonHangMoi;
            ViewData["DonHangDangGiao"] = listDonHangDangGiao;
            ViewData["DonHangDaThanhToan"] = listDonHangDaThanhToan;
            ViewBag.SoDonHangMoi = 0;

            return View("QuanLyDonHang");
        }

        [HttpGet]
        [Authorize]
        public ActionResult QuanLyTaiKhoan()
        {
            ViewData["ListTaiKhoan"] = db.TaiKhoanContext.OrderByDescending(tk => tk.QuyenAdmin).ToList();
            ViewBag.SoDonHangMoi = ThongKeDonHangMoi();
            return View("QuanLyTaiKhoan");
        }

        [HttpPost]
        [Authorize]
        public ActionResult ToggleHienThiTrangChu(int sanPhamId)
        {
            SanPham sanPham = GetSanPham(sanPhamId);
            sanPham.HienThiTrangChu = !sanPham.HienThiTrangChu;
            UpdateSanPhamToDatabase(sanPham);
            return Json(new { error = false });
        }

        [HttpPost]
        [Authorize]
        public JsonResult GetSanPhamUpdate(int sanPhamId)
        {
            db.Configuration.LazyLoadingEnabled = false;

            SanPham sanPham = GetSanPham(sanPhamId);

            sanPham.CauHinhSanPham = db.CauHinhSanPhamContext.Find(sanPham.SanPhamId);
            sanPham.KhuyenMai = db.KhuyenMaiContext.Find(sanPham.SanPhamId);
            sanPham.ListHinhAnhSanPham = db.HinhAnhSanPhamContext.Where(hasp => hasp.SanPhamId == sanPham.SanPhamId).ToList();

            var jsonResult = JsonConvert.SerializeObject(sanPham, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            db.Configuration.LazyLoadingEnabled = true;

            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public JsonResult DeleteSanPham(int idSanPham)
        {
            SanPham sanPham = db.SanPhamContext.Find(idSanPham);

            if (sanPham == null)
                return Json(new { error = true });

            var listHinhAnhSanPham = db.HinhAnhSanPhamContext.Where(hasp => hasp.SanPhamId == sanPham.SanPhamId).ToList();
            foreach (var ha in listHinhAnhSanPham)
                db.HinhAnhSanPhamContext.Remove(ha);

            var chsp = db.CauHinhSanPhamContext.Find(sanPham.SanPhamId);
            db.CauHinhSanPhamContext.Remove(chsp);

            var listDonHang = db.DonHangContext.Where(dh => dh.SanPhamId == sanPham.SanPhamId).ToList();
            foreach (var dh in listDonHang)
            {
                dh.SanPhamId = null;
                db.DonHangContext.AddOrUpdate(dh);
                db.SaveChanges();
            }

            var khuyenMai = db.KhuyenMaiContext.Find(sanPham.SanPhamId);
            if (khuyenMai != null)
                db.KhuyenMaiContext.Remove(khuyenMai);

            db.SanPhamContext.Remove(sanPham);

            db.SaveChanges();

            return Json(new { error = false });
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetHangSanXuat()
        {
            db.Configuration.LazyLoadingEnabled = false;

            var listHangSanXuat = db.HangSanXuatContext.ToList();
            var json = JsonConvert.SerializeObject(listHangSanXuat);

            db.Configuration.LazyLoadingEnabled = true;

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetLoaiSanPham()
        {
            db.Configuration.LazyLoadingEnabled = false;

            var listLoaiSanPham = db.LoaiSanPhamContext.ToList();
            var json = JsonConvert.SerializeObject(listLoaiSanPham);

            db.Configuration.LazyLoadingEnabled = true;

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ThemSanPham([System.Web.Http.FromBody]string json)
        {
            var body = JsonConvert.DeserializeObject<dynamic>(json);

            // SanPham
            string tenSanPham = body["TenSanPham"];
            double giaNhapHang = body["GiaNhapHang"];
            double giaBan = body["GiaBan"];
            bool hienThiTrangChu = body["HienThiTrangChu"];
            int idLoaiSanPham = body["IdLoaiSanPham"];
            int idHangSanXuat = body["IdHangSanXuat"];
            int soLuongKho = body["SoLuongKho"];
            
            SanPham sanPham = new SanPham()
            { 
                TenSanPham = tenSanPham,
                GiaNhapHang = giaNhapHang,
                GiaBan = giaBan,
                HienThiTrangChu = hienThiTrangChu,
                LoaiSanPhamId = idLoaiSanPham,
                HangSanXuatId = idHangSanXuat,
                SoLuongKho = soLuongKho
            };

            db.SanPhamContext.Add(sanPham);
            db.SaveChanges();

            // CauHinhSanPham
            dynamic bodyCauHinhSanPham = body["CauHinhSanPham"];
            string manHinh = bodyCauHinhSanPham["ManHinh"];
            string heDieuHanh = bodyCauHinhSanPham["HeDieuHanh"];
            string cameraTruoc = bodyCauHinhSanPham["CameraTruoc"];
            string cameraSau = bodyCauHinhSanPham["CameraSau"];
            string CPU = bodyCauHinhSanPham["CPU"];
            string GPU = bodyCauHinhSanPham["GPU"];
            string sim = bodyCauHinhSanPham["Sim"];
            string pin = bodyCauHinhSanPham["Pin"];
            string RAM = bodyCauHinhSanPham["RAM"];
            string ROM = bodyCauHinhSanPham["ROM"];

            CauHinhSanPham cauHinhSanPham = new CauHinhSanPham()
            {
                ManHinh = manHinh,
                HeDieuHanh = heDieuHanh,
                CameraTruoc = cameraTruoc,
                CameraSau = cameraSau,
                CPU = CPU,
                GPU = GPU,
                Sim = sim,
                Pin = pin,
                RAM = RAM,
                ROM = ROM,
                SanPhamId = sanPham.SanPhamId
            };

            db.CauHinhSanPhamContext.Add(cauHinhSanPham);
            db.SaveChanges();

            // KhuyenMai
            dynamic bodyKhuyenMai = body["KhuyenMai"];
            try
            {
                double soTienGiam = bodyKhuyenMai["SoTienGiam"];

                KhuyenMai khuyenMai = new KhuyenMai()
                {
                    SanPhamId = sanPham.SanPhamId,
                    SoTienGiam = soTienGiam
                };

                db.KhuyenMaiContext.Add(khuyenMai);
                db.SaveChanges();
            }
            catch (Exception e) {}

            // HinhAnhSanPham
            string imgDaiDien = body["HinhDaiDien"];
            
            dynamic bodyHinhAnhSanPham = body["ListHinhAnhSanPham"];
            
            foreach (var hasp in bodyHinhAnhSanPham)
            {
                string imgData = hasp["data"];
                string filename = hasp["filename"];
                bool hinhDaiDien = false;

                try
                {
                    hinhDaiDien = hasp["hinhDaiDien"];
                }
                catch (Exception e) {}

                Bitmap image = null;
                
                imgData = imgData.Substring(imgData.IndexOf(',') + 1);
                byte[] byteBuffer = Convert.FromBase64String(imgData);
                MemoryStream streamBitmap = new MemoryStream(byteBuffer);
                image = (Bitmap)Image.FromStream(streamBitmap);
                
                filename = "images/" + DateTime.Now.Ticks.ToString() + "_" + filename; 
                image.Save(Server.MapPath("/Content/") + filename);

                HinhAnhSanPham hinhAnhSanPham = new HinhAnhSanPham()
                {
                    SanPhamId = sanPham.SanPhamId,
                    ImagePath = filename
                };

                if (hinhDaiDien)
                {
                    sanPham.ImgDaiDien = filename;
                    db.SanPhamContext.AddOrUpdate(sanPham);
                    db.SaveChanges();
                }

                db.HinhAnhSanPhamContext.Add(hinhAnhSanPham);
                db.SaveChanges();
            }

            return Json(new { error = false });
        }

        [HttpPost]
        [Authorize]
        public ActionResult CapNhatSanPham([System.Web.Http.FromBody]string json)
        {
            var body = JsonConvert.DeserializeObject<dynamic>(json);

            // SanPham
            int idSanPham = body["IdSanPham"];

            SanPham sanPham = db.SanPhamContext.Find(idSanPham);

            if (sanPham == null)
                return Json(new { error = true });

            string tenSanPham = body["TenSanPham"];
            double giaNhapHang = body["GiaNhapHang"];
            double giaBan = body["GiaBan"];
            bool hienThiTrangChu = body["HienThiTrangChu"];
            int idLoaiSanPham = body["IdLoaiSanPham"];
            int idHangSanXuat = body["IdHangSanXuat"];
            int soLuongKho = body["SoLuongKho"];

            sanPham.TenSanPham = tenSanPham;
            sanPham.GiaNhapHang = giaNhapHang;
            sanPham.GiaBan = giaBan;
            sanPham.HienThiTrangChu = hienThiTrangChu;
            sanPham.HangSanXuatId = idHangSanXuat;
            sanPham.LoaiSanPhamId = idLoaiSanPham;
            sanPham.SoLuongKho = soLuongKho;

            db.SanPhamContext.AddOrUpdate(sanPham);

            // CauHinhSanPham
            dynamic bodyCauHinhSanPham = body["CauHinhSanPham"];
            string manHinh = bodyCauHinhSanPham["ManHinh"];
            string heDieuHanh = bodyCauHinhSanPham["HeDieuHanh"];
            string cameraTruoc = bodyCauHinhSanPham["CameraTruoc"];
            string cameraSau = bodyCauHinhSanPham["CameraSau"];
            string CPU = bodyCauHinhSanPham["CPU"];
            string GPU = bodyCauHinhSanPham["GPU"];
            string sim = bodyCauHinhSanPham["Sim"];
            string pin = bodyCauHinhSanPham["Pin"];
            string RAM = bodyCauHinhSanPham["RAM"];
            string ROM = bodyCauHinhSanPham["ROM"];

            CauHinhSanPham cauHinhSanPham = db.CauHinhSanPhamContext.Find(idSanPham);
            cauHinhSanPham = new CauHinhSanPham()
            {
                ManHinh = manHinh,
                HeDieuHanh = heDieuHanh,
                CameraTruoc = cameraTruoc,
                CameraSau = cameraSau,
                CPU = CPU,
                GPU = GPU,
                Sim = sim,
                Pin = pin,
                RAM = RAM,
                ROM = ROM,
                SanPhamId = sanPham.SanPhamId
            };

            db.CauHinhSanPhamContext.AddOrUpdate(cauHinhSanPham);
            db.SaveChanges();

            // KhuyenMai
            dynamic bodyKhuyenMai = body["KhuyenMai"];
            KhuyenMai khuyenMai = db.KhuyenMaiContext.Find(idSanPham);

            if (bodyKhuyenMai == null && khuyenMai != null)
                db.KhuyenMaiContext.Remove(khuyenMai);
            else if (bodyKhuyenMai != null)
            {
                khuyenMai = new KhuyenMai()
                {
                    SoTienGiam = bodyKhuyenMai["SoTienGiam"],
                    SanPhamId = idSanPham
                };
                db.KhuyenMaiContext.AddOrUpdate(khuyenMai);
            }
            
            // HinhAnhSanPham
            List<HinhAnhSanPham> listHinhAnhSanPham = db.HinhAnhSanPhamContext.Where(hasp => hasp.SanPhamId == idSanPham).ToList();
            List<HinhAnhSanPham> deletedImage = new List<HinhAnhSanPham>(listHinhAnhSanPham);

            string imgDaiDien = body["HinhDaiDien"];

            dynamic bodyHinhAnhSanPham = body["ListHinhAnhSanPham"];

            foreach (var hasp in bodyHinhAnhSanPham)
            {
                string imgData = hasp["data"];
                string filename = hasp["filename"];
                bool hinhDaiDien = false;

                try
                {
                    hinhDaiDien = hasp["hinhDaiDien"];
                }
                catch (Exception e) { }

                if (imgData.IndexOf("base64") > 0)
                {
                    Bitmap image = null;

                    imgData = imgData.Substring(imgData.IndexOf(',') + 1);
                    byte[] byteBuffer = Convert.FromBase64String(imgData);
                    MemoryStream streamBitmap = new MemoryStream(byteBuffer);
                    image = (Bitmap)Image.FromStream(streamBitmap);

                    filename = "images/" + DateTime.Now.Ticks.ToString() + "_" + filename;
                    image.Save(Server.MapPath("/Content/") + filename);

                    HinhAnhSanPham hinhAnhSanPham = new HinhAnhSanPham()
                    {
                        SanPhamId = sanPham.SanPhamId,
                        ImagePath = filename
                    };

                    if (hinhDaiDien)
                    {
                        sanPham.ImgDaiDien = filename;
                        db.SanPhamContext.AddOrUpdate(sanPham);
                        db.SaveChanges();
                    }

                    db.HinhAnhSanPhamContext.Add(hinhAnhSanPham);
                    db.SaveChanges();
                }
                else
                {
                    listHinhAnhSanPham.ForEach(ha =>
                    {
                        if (ha.ImagePath.EndsWith(filename))
                        {
                            deletedImage.Remove(ha);
                        }
                    });
                }
            }

            deletedImage.ForEach(ha =>
            {
                db.HinhAnhSanPhamContext.Remove(ha);
                System.IO.File.Delete(Server.MapPath("/Content/") + ha.ImagePath);
            });
            db.SaveChanges();
            
            return Json(new { error = false });
        }

        private SanPham GetSanPham(int sanPhamId)
        {
            var sanPham = db.SanPhamContext.Where(sp => sp.SanPhamId == sanPhamId).First();
            return sanPham;
        }

        private void UpdateSanPhamToDatabase(SanPham sanPham)
        {
            db.SanPhamContext.AddOrUpdate(sanPham);
            db.SaveChanges();
        }
        

        // QuanLyDonHang
        [HttpPost]
        [Authorize]
        public ActionResult XoaDonHang(int idDonHang)
        {
            DonHang donHang = db.DonHangContext.Find(idDonHang);

            if (donHang == null)
            {
                return Json(new { error = true }, JsonRequestBehavior.AllowGet);
            }

            db.DonHangContext.Remove(donHang);
            db.SaveChanges();

            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CapNhatTrangThaiDonHang(int idDonHang, string trangThai)
        {
            DonHang donHang = db.DonHangContext.Find(idDonHang);

            if (donHang.TrangThaiDonHang == "Mới" && trangThai == "Đang giao hàng")
            {
                donHang.TrangThaiDonHang = trangThai;
                SanPham sanPham = db.SanPhamContext.Find(donHang.SanPhamId);
                sanPham.SoLuongKho = sanPham.SoLuongKho - 1;
                db.SanPhamContext.AddOrUpdate(sanPham);
                donHang.UpdatedAt = DateTime.Now.Ticks;
                db.SaveChanges();
            }

            if (donHang.TrangThaiDonHang == "Đang giao hàng" && trangThai == "Mới")
            {
                donHang.TrangThaiDonHang = trangThai;
                SanPham sanPham = db.SanPhamContext.Find(donHang.SanPhamId);
                sanPham.SoLuongKho = sanPham.SoLuongKho + 1;
                donHang.GiamGia = sanPham.KhuyenMai != null ? sanPham.KhuyenMai.SoTienGiam : 0;
                donHang.UpdatedAt = DateTime.Now.Ticks;
                db.SanPhamContext.AddOrUpdate(sanPham);
                db.SaveChanges();
            }

            if (donHang.TrangThaiDonHang == "Đang giao hàng" && trangThai == "Đã thanh toán")
            {
                donHang.TrangThaiDonHang = trangThai;
                donHang.NgayThanhToan = DateTime.Now;
                donHang.UpdatedAt = DateTime.Now.Ticks;
            }

            db.DonHangContext.AddOrUpdate(donHang);
            db.SaveChanges();

            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult ThemTaiKhoan(string username)
        {
            int taiKhoan = db.TaiKhoanContext.Where(tk => tk.Username == username).Count();

            if (taiKhoan > 0)
                return Json(new {error = true}, JsonRequestBehavior.AllowGet);

            TaiKhoan taiKhoanMoi = new TaiKhoan()
            {
                Username = username,
                Hash = BCrypt.Net.BCrypt.HashPassword("123456"),
                QuyenAdmin = false
            };

            db.TaiKhoanContext.Add(taiKhoanMoi);
            db.SaveChanges();

            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult XoaTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoanContext.Find(id);

            if (taiKhoan == null)
                return Json(new { error = true }, JsonRequestBehavior.AllowGet);

            TaiKhoan currentUser = db.TaiKhoanContext.Where(tk => tk.Username == User.Identity.Name).First();

            if (currentUser == null || currentUser.QuyenAdmin != true)
                return Json(new { error = true }, JsonRequestBehavior.AllowGet);

            if (taiKhoan.QuyenAdmin == true)
                return Json(new { error = true }, JsonRequestBehavior.AllowGet);

            db.TaiKhoanContext.Remove(taiKhoan);
            db.SaveChanges();

            return Json(new { error = false }, JsonRequestBehavior.AllowGet);
        }
	}

    public class FormDoiMatKhau
    {
        public string MatKhau { get; set; }
        public string MatKhauMoi { get; set; }
        public string NhapLaiMatKhauMoi { get; set; }
    }
}