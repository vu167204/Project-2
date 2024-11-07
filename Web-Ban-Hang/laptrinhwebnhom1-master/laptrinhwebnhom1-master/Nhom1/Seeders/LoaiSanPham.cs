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
        public void SeedLoaiSanPham()
        {
            context_.LoaiSanPhamContext.AddOrUpdate(new LoaiSanPham() { LoaiSanPhamId = 1, TenLoaiSanPham = "Điện thoại" });
            context_.LoaiSanPhamContext.AddOrUpdate(new LoaiSanPham() { LoaiSanPhamId = 2, TenLoaiSanPham = "Máy tính bảng" });

            context_.SaveChanges();
        }
    }
}