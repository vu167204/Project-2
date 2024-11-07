using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Nhom1.Models
{
    public class Nhom1DBContext : DbContext
    {
        public Nhom1DBContext()
            :base("Nhom1DB")
        {
        }

        public DbSet<SanPham> SanPhamContext { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhamContext { get; set; }
        public DbSet<HangSanXuat> HangSanXuatContext { get; set; }
        public DbSet<CauHinhSanPham> CauHinhSanPhamContext { get; set; }
        public DbSet<HinhAnhSanPham> HinhAnhSanPhamContext { get; set; }
        public DbSet<KhuyenMai> KhuyenMaiContext { get; set; }
        public DbSet<TaiKhoan> TaiKhoanContext { get; set; }
        public DbSet<DonHang> DonHangContext { get; set; }
    }
}