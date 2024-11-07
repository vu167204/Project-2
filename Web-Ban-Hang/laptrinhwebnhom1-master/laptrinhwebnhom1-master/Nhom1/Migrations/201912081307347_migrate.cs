namespace Nhom1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CauHinhSanPham",
                c => new
                    {
                        SanPhamId = c.Int(nullable: false),
                        ManHinh = c.String(),
                        HeDieuHanh = c.String(),
                        CameraTruoc = c.String(),
                        CameraSau = c.String(),
                        Sim = c.String(),
                        Pin = c.String(),
                        CPU = c.String(),
                        GPU = c.String(),
                        ROM = c.String(),
                        RAM = c.String(),
                    })
                .PrimaryKey(t => t.SanPhamId)
                .ForeignKey("dbo.SanPham", t => t.SanPhamId)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        SanPhamId = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(nullable: false, maxLength: 100),
                        GiaNhapHang = c.Double(nullable: false),
                        GiaBan = c.Double(nullable: false),
                        SoLuongKho = c.Int(nullable: false),
                        HienThiTrangChu = c.Boolean(nullable: false),
                        MoTa = c.String(),
                        LuotXem = c.Int(nullable: false),
                        ImgDaiDien = c.String(),
                        LoaiSanPhamId = c.Int(nullable: false),
                        HangSanXuatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SanPhamId)
                .ForeignKey("dbo.HangSanXuat", t => t.HangSanXuatId, cascadeDelete: true)
                .ForeignKey("dbo.LoaiSanPham", t => t.LoaiSanPhamId, cascadeDelete: true)
                .Index(t => t.HangSanXuatId)
                .Index(t => t.LoaiSanPhamId);
            
            CreateTable(
                "dbo.HangSanXuat",
                c => new
                    {
                        HangSanXuatId = c.Int(nullable: false, identity: true),
                        TenHangSanXuat = c.String(nullable: false, maxLength: 100),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.HangSanXuatId);
            
            CreateTable(
                "dbo.KhuyenMai",
                c => new
                    {
                        SanPhamId = c.Int(nullable: false),
                        SoTienGiam = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SanPhamId)
                .ForeignKey("dbo.SanPham", t => t.SanPhamId)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.HinhAnhSanPham",
                c => new
                    {
                        HinhAnhSanPhamId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        SanPhamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HinhAnhSanPhamId)
                .ForeignKey("dbo.SanPham", t => t.SanPhamId, cascadeDelete: true)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        LoaiSanPhamId = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.LoaiSanPhamId);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        DonHangId = c.Int(nullable: false, identity: true),
                        TrangThaiDonHang = c.String(),
                        NgayThanhToan = c.DateTime(),
                        HoTen = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                        DiaChi = c.String(),
                        SoLuong = c.Int(nullable: false),
                        GiaBan = c.Double(nullable: false),
                        GiaNhapHang = c.Double(nullable: false),
                        GiamGia = c.Double(nullable: false),
                        UpdatedAt = c.Long(nullable: false),
                        SanPhamId = c.Int(),
                    })
                .PrimaryKey(t => t.DonHangId)
                .ForeignKey("dbo.SanPham", t => t.SanPhamId)
                .Index(t => t.SanPhamId);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        TaiKhoanId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Hash = c.String(),
                        QuyenAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaiKhoanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonHang", "SanPhamId", "dbo.SanPham");
            DropForeignKey("dbo.CauHinhSanPham", "SanPhamId", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "LoaiSanPhamId", "dbo.LoaiSanPham");
            DropForeignKey("dbo.HinhAnhSanPham", "SanPhamId", "dbo.SanPham");
            DropForeignKey("dbo.KhuyenMai", "SanPhamId", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "HangSanXuatId", "dbo.HangSanXuat");
            DropIndex("dbo.DonHang", new[] { "SanPhamId" });
            DropIndex("dbo.CauHinhSanPham", new[] { "SanPhamId" });
            DropIndex("dbo.SanPham", new[] { "LoaiSanPhamId" });
            DropIndex("dbo.HinhAnhSanPham", new[] { "SanPhamId" });
            DropIndex("dbo.KhuyenMai", new[] { "SanPhamId" });
            DropIndex("dbo.SanPham", new[] { "HangSanXuatId" });
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.DonHang");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.HinhAnhSanPham");
            DropTable("dbo.KhuyenMai");
            DropTable("dbo.HangSanXuat");
            DropTable("dbo.SanPham");
            DropTable("dbo.CauHinhSanPham");
        }
    }
}
