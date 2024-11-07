using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nhom1.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int TaiKhoanId { get; set; }
        public string Username { get; set; }
        public string  Hash { get; set; }
        public bool QuyenAdmin { get; set; }
    }
}