using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int SanPhamId { get; set; }
        [StringLength(100)]
        [Required]
        public string TenSanPham { get; set; }
        public double GiaNhapHang { get; set; }
        [Required]
        public double GiaBan { get; set; }
        public int SoLuongKho { get; set; }
        public bool HienThiTrangChu { get; set; }
        public string MoTa { get; set; }
        public int LuotXem { get; set; }
        public string ImgDaiDien { get; set; }

        [ForeignKey("LoaiSanPham")]
        public int LoaiSanPhamId { get; set; }
        [ForeignKey("HangSanXuat")]
        public int HangSanXuatId { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual HangSanXuat HangSanXuat { get; set; }
        public virtual CauHinhSanPham CauHinhSanPham { get; set; }
        public virtual List<HinhAnhSanPham> ListHinhAnhSanPham { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
    }
}