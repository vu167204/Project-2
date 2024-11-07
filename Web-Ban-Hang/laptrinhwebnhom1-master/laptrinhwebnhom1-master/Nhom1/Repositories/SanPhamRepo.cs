using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom1.Models;

namespace Nhom1.Repositories
{
    public class SanPhamRepo
    {
        public static List<SanPham> LoadListSanPham(string tenLoaiSanPham)
        {
            Nhom1DBContext context = new Nhom1DBContext();

            var loaiSanPham = context.LoaiSanPhamContext.Where(lsp => lsp.TenLoaiSanPham == tenLoaiSanPham).First();
            var listSanPham = context.SanPhamContext.Where(sanPham => sanPham.LoaiSanPhamId == loaiSanPham.LoaiSanPhamId).ToList();

            foreach (var sanPham in listSanPham)
            {
                var khuyenMai = context.KhuyenMaiContext.Where(km => km.SanPhamId == sanPham.SanPhamId).FirstOrDefault();
                var cauHinhSanPham = context.CauHinhSanPhamContext.Where(chsp => chsp.SanPhamId == sanPham.SanPhamId).FirstOrDefault();
                var listHinhAnhSanPham = context.HinhAnhSanPhamContext.Where(hasp => hasp.SanPhamId == sanPham.SanPhamId).ToList();

                sanPham.KhuyenMai = khuyenMai != null ? khuyenMai : null;
                sanPham.CauHinhSanPham = cauHinhSanPham;
                sanPham.ListHinhAnhSanPham = listHinhAnhSanPham;
            }

            return listSanPham;
        }
    }
}