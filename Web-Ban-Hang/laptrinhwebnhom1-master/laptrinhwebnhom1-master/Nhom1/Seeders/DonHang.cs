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
        public void SeedDonHang()
        {
            DateTime datetime = new DateTime(2018, 1, 1);
            DateTime today = DateTime.Today;

            while (DateTime.Compare(datetime, today) <= 0)
            {
                int soLuongDonHang = GetRandomNumber(1, 6);

                SeedRandomDonHang(datetime, soLuongDonHang);

                int daysSkip = GetRandomNumber(1, 4); // 1 - 3
                datetime = datetime.AddDays(daysSkip);
            }

            DonHang donHangMoi = new DonHang()
            {
                TrangThaiDonHang = "Mới",
                NgayThanhToan = DateTime.Now,
                HoTen = "QWER",
                SoDienThoai = "0123456789",
                Email = "qwer@q.c",
                DiaChi = "QWER st",
                SoLuong = 1,
                GiaBan = 100000,
                GiaNhapHang = 90000,
                SanPhamId = 2
            };

            context_.DonHangContext.AddOrUpdate(donHangMoi);
            context_.SaveChanges();

            DonHang donHangDangGiao = new DonHang()
            {
                TrangThaiDonHang = "Đang giao hàng",
                NgayThanhToan = DateTime.Now,
                HoTen = "QWER",
                SoDienThoai = "0123456789",
                Email = "qwer@q.c",
                DiaChi = "QWER st",
                SoLuong = 1,
                GiaBan = 1000000,
                GiaNhapHang = 900000,
                SanPhamId = 2
            };

            context_.DonHangContext.AddOrUpdate(donHangDangGiao);
            context_.SaveChanges();
        }

        private void SeedRandomDonHang(DateTime thoiGian, int soLuongDonHang)
        {
            for (int i = 0; i < soLuongDonHang; i++)
            {
                SanPham randomSanPham = GetRandomSanPham();

                DonHang donHang = new DonHang()
                {
                    TrangThaiDonHang = "Đã thanh toán",
                    NgayThanhToan = thoiGian,
                    HoTen = "QWER",
                    SoDienThoai = "0123456789",
                    Email = "qwer@q.c",
                    DiaChi = "QWER st",
                    SoLuong = 1,
                    GiaBan = randomSanPham.GiaBan,
                    GiaNhapHang = randomSanPham.GiaNhapHang,
                    SanPhamId = randomSanPham.SanPhamId,
                    UpdatedAt = DateTime.Now.Ticks
                };

                context_.DonHangContext.AddOrUpdate(donHang);
                context_.SaveChanges();
            }
        }

        private SanPham GetRandomSanPham()
        {
            int firstIdSanPham = 1;
            int lastIdSanPham = context_.SanPhamContext.Count();

            return context_.SanPhamContext.Find(GetRandomNumber(firstIdSanPham, lastIdSanPham + 1));
        }
    }
}