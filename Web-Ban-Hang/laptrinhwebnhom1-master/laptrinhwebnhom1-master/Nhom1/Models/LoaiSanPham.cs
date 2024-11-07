using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("LoaiSanPham")]
    public class LoaiSanPham
    {
        [Key]
        public int LoaiSanPhamId { get; set; }
        [StringLength(100)]
        public string TenLoaiSanPham { get; set; }
        public virtual List<SanPham> ListSanPham { get; set; }
    }
}