using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("KhuyenMai")]
    public class KhuyenMai
    {
        [ForeignKey("SanPham"), Key]
        public int SanPhamId { get; set; }
        public double SoTienGiam { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}