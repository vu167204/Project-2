using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("CauHinhSanPham")]
    public class CauHinhSanPham
    {
        [ForeignKey("SanPham"), Key]
        public int SanPhamId { get; set; }
        public string ManHinh { get; set; }
        public string HeDieuHanh { get; set; }
        public string CameraTruoc { get; set; }
        public string CameraSau { get; set; }   
        public string Sim { get; set; }
        public string Pin { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string ROM { get; set; }
        public string RAM { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}