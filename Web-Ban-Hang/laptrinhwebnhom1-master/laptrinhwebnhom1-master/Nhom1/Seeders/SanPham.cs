using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom1.Models;
using System.Data.Entity.Migrations;

namespace Nhom1.Seeders
{
    public partial class Seeder
    {
        public void SeedSanPham()
        {
            // Điện thoại
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 1, TenSanPham = "iPhone 11 Pro Max 512GB", GiaNhapHang = 43000000, GiaBan = 43990000, LoaiSanPhamId = 1, HangSanXuatId = 1, HienThiTrangChu = true, ImgDaiDien = "images/iphone-11-pro-max-512gb-gold-400x460.png", SoLuongKho = 1 });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 2, TenSanPham = "iPhone 6s Plus 32GB", GiaNhapHang = 8000000, GiaBan = 8990000, LoaiSanPhamId = 1, HangSanXuatId = 1, ImgDaiDien = "images/iphone-6s-plus-32gb-rose-gold-400x460.png" });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 3, TenSanPham = "Samsung Galaxy S10+", GiaNhapHang = 28000000, GiaBan = 28990000, LoaiSanPhamId = 1, HangSanXuatId = 2, HienThiTrangChu = true, ImgDaiDien = "images/sieu-pham-galaxy-s-moi-2-512gb-black-400x460.png", SoLuongKho = 1 });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 4, TenSanPham = "Samsung Galaxy A10", GiaNhapHang = 3000000, GiaBan = 3090000, LoaiSanPhamId = 1, HangSanXuatId = 2, ImgDaiDien = "images/samsung-galaxy-a10-red-400x460.png" });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 5, TenSanPham = "OPPO Reno 10x Zoom Edition", GiaNhapHang = 20000000, GiaBan = 20990000, LoaiSanPhamId = 1, HangSanXuatId = 3, HienThiTrangChu = true, ImgDaiDien = "images/oppo-reno-10x-zoom-edition-black-400x460.png", SoLuongKho = 1 });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 6, TenSanPham = "OPPO A1K", GiaNhapHang = 3100000, GiaBan = 3190000, LoaiSanPhamId = 1, HangSanXuatId = 3, ImgDaiDien = "images/oppo-a1k-red-400x460.png" });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 7, TenSanPham = "Huawei P30 Pro", GiaNhapHang = 22000000, GiaBan = 22990000, LoaiSanPhamId = 1, HangSanXuatId = 4, HienThiTrangChu = true, ImgDaiDien = "images/huawei-p30-pro-1-400x460.png", SoLuongKho = 1 });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 8, TenSanPham = "Huawei Y7 Pro (2019)", GiaNhapHang = 3400000, GiaBan = 3490000, LoaiSanPhamId = 1, HangSanXuatId = 4, ImgDaiDien = "images/huawei-y7-pro-2019-400x460.png" });

            // Máy tính bảng
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 9, TenSanPham = "iPad Pro 11 inch Wifi 64GB (2018)", GiaNhapHang = 21000000, GiaBan = 21990000, LoaiSanPhamId = 2, HangSanXuatId = 1, HienThiTrangChu = true, ImgDaiDien = "images/ipad-pro-11-inch-2018-64gb-wifi-33397-chitiet-400x460.png" });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 10, TenSanPham = "iPad Wifi 32GB (2018)", GiaNhapHang = 7000000, GiaBan = 7990000, LoaiSanPhamId = 2, HangSanXuatId = 1, ImgDaiDien = "images/ipad-6th-wifi-32gb-1-400x460.png" });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 11, TenSanPham = "Samsung Galaxy Tab S6", GiaNhapHang = 18400000, GiaBan = 18490000, LoaiSanPhamId = 2, HangSanXuatId = 2, HienThiTrangChu = true, ImgDaiDien = "images/samsung-galaxy-tab-s6-400x460.png" });
            context_.SanPhamContext.AddOrUpdate(new SanPham() { SanPhamId = 12, TenSanPham = "Samsung Galaxy Tab A8 8\" T295 (2019)", GiaNhapHang = 3600000, GiaBan = 3690000, LoaiSanPhamId = 2, HangSanXuatId = 2, ImgDaiDien = "images/samsung-galaxy-tab-a8-t295-2019-silver-400x460.png" });

            context_.SaveChanges();
        }
    }
}