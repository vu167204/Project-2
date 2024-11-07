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
        public void SeedHangSanXuat()
        {
            context_.HangSanXuatContext.AddOrUpdate(new HangSanXuat() { HangSanXuatId = 1, TenHangSanXuat = "Apple", LogoUrl = "/images/apple-logo.png" });
            context_.HangSanXuatContext.AddOrUpdate(new HangSanXuat() { HangSanXuatId = 2, TenHangSanXuat = "Samsung", LogoUrl = "/images/samsung-logo.png" });
            context_.HangSanXuatContext.AddOrUpdate(new HangSanXuat() { HangSanXuatId = 3, TenHangSanXuat = "Oppo", LogoUrl = "/images/oppo-logo.png" });
            context_.HangSanXuatContext.AddOrUpdate(new HangSanXuat() { HangSanXuatId = 4, TenHangSanXuat = "Huawei", LogoUrl = "/images/huawei-logo.png" });

            context_.SaveChanges();
        }
    }
}