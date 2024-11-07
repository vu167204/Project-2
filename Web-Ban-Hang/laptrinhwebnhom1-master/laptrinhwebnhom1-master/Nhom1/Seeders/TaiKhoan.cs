using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom1.Models;
using System.Data.Entity.Migrations;
using BCrypt.Net;

namespace Nhom1.Seeders
{
    public partial class Seeder
    {
        public void SeedTaiKhoan()
        {
            context_.TaiKhoanContext.AddOrUpdate(new TaiKhoan() { 
                TaiKhoanId = 1,
                Username = "admin",
                Hash = BCrypt.Net.BCrypt.HashPassword("123456", 10),
                QuyenAdmin = true
            });
            context_.TaiKhoanContext.AddOrUpdate(new TaiKhoan()
            {
                TaiKhoanId = 2,
                Username = "user1",
                Hash = BCrypt.Net.BCrypt.HashPassword("123456", 10)
            });
            context_.TaiKhoanContext.AddOrUpdate(new TaiKhoan()
            {
                TaiKhoanId = 3,
                Username = "user2",
                Hash = BCrypt.Net.BCrypt.HashPassword("123456", 10)
            });
            context_.TaiKhoanContext.AddOrUpdate(new TaiKhoan()
            {
                TaiKhoanId = 4,
                Username = "user3",
                Hash = BCrypt.Net.BCrypt.HashPassword("123456", 10)
            });

            context_.SaveChanges();
        }
    }
}