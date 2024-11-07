using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("HinhAnhSanPham")]
    public class HinhAnhSanPham
    {
        [Key]
        public int HinhAnhSanPhamId { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("SanPham")]
        public int SanPhamId { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}