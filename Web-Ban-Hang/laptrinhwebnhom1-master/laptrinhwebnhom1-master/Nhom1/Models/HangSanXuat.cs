using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("HangSanXuat")]
    public class HangSanXuat
    {
        [Key]
        public int HangSanXuatId { get; set; }
        [Required]
        [StringLength(100)]
        public string TenHangSanXuat { get; set; }
        public string LogoUrl { get; set; }

        public virtual List<SanPham> ListSanPham { get; set; }
    }
}