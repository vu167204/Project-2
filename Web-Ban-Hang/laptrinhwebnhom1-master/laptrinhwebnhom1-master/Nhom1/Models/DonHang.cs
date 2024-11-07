using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int DonHangId { get; set; }
        public string TrangThaiDonHang { get; set; }
        public DateTime? NgayThanhToan { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
        public double GiaNhapHang { get; set; }
        public double GiamGia { get; set; }

        public long UpdatedAt { get; set; }

        [ForeignKey("SanPham")]
        public int? SanPhamId { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}