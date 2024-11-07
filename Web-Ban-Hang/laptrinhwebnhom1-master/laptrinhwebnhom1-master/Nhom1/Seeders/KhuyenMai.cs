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
        public void SeedKhuyenMai()
        {
            context_.KhuyenMaiContext.AddOrUpdate(new KhuyenMai() {
                SanPhamId = 3, 
                SoTienGiam=6000000
            });
            context_.KhuyenMaiContext.AddOrUpdate(new KhuyenMai()
            {
                SanPhamId = 5,
                SoTienGiam = 4000000
            });
            context_.KhuyenMaiContext.AddOrUpdate(new KhuyenMai()
            {
                SanPhamId = 7,
                SoTienGiam = 2300000
            });
            context_.KhuyenMaiContext.AddOrUpdate(new KhuyenMai()
            {
                SanPhamId = 8,
                SoTienGiam = 350000
            });

            context_.SaveChanges();
        }
    }
}