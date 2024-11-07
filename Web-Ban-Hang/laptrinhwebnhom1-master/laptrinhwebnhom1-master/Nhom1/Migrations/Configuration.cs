namespace Nhom1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Nhom1.Models;
    using Nhom1.Seeders;

    internal sealed class Configuration : DbMigrationsConfiguration<Nhom1.Models.Nhom1DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Nhom1DBContext context)
        {
            Seeder seeder = new Seeder(context);

            seeder.SeedLoaiSanPham();
            seeder.SeedHangSanXuat();
            seeder.SeedSanPham();
            seeder.SeedCauHinhSanPham();
            seeder.SeedHinhAnhSanPham();
            seeder.SeedKhuyenMai();
            seeder.SeedTaiKhoan();
            seeder.SeedDonHang();
        }
    }
}
