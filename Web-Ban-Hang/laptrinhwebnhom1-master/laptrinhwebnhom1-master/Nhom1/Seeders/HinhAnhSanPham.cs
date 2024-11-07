using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nhom1.Models;
using System.Data.Entity.Migrations;

namespace Nhom1.Seeders
{
    public partial class Seeder
    {
        public void SeedHinhAnhSanPham()
        {
            // iPhone 11 Pro Max 512GB
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 1,
                HinhAnhSanPhamId = 1,
                ImagePath = "images/iphone-11-pro-max-512gb-gold-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 1,
                HinhAnhSanPhamId = 2,
                ImagePath = "images/iphone-11-pro-max-512gb-xanh-1-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 1,
                HinhAnhSanPhamId = 3,
                ImagePath = "images/iphone-11-pro-max-512gb-xam-5-org.jpg"
            });

            // iPhone 6s Plus 32GB
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 2,
                HinhAnhSanPhamId = 4,
                ImagePath = "images/iphone-6s-plus-32gb-rose-gold-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 2,
                HinhAnhSanPhamId = 5,
                ImagePath = "images/iphone-6s-plus-32gb-vanghong1-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 2,
                HinhAnhSanPhamId = 6,
                ImagePath = "images/iphone-6s-plus-32gb-vanghong1-3-org.jpg"
            });

            // Samsung Galaxy S10+
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 3,
                HinhAnhSanPhamId = 7,
                ImagePath = "images/sieu-pham-galaxy-s-moi-2-512gb-black-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 3,
                HinhAnhSanPhamId = 8,
                ImagePath = "images/samsung-galaxy-s10-plus-512gb-den-2-1-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 3,
                HinhAnhSanPhamId = 9,
                ImagePath = "images/samsung-galaxy-s10-plus-512gb-den-3-2-org.jpg"
            });

            // Samsung Galaxy A10
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 4,
                HinhAnhSanPhamId = 10,
                ImagePath = "images/samsung-galaxy-a10-red-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 4,
                HinhAnhSanPhamId = 11,
                ImagePath = "images/samsung-galaxy-a10-do-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 4,
                HinhAnhSanPhamId = 12,
                ImagePath = "images/samsung-galaxy-a10-do-3-org.jpg"
            });

            // OPPO Reno 10x Zoom Edition
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 5,
                HinhAnhSanPhamId = 13,
                ImagePath = "images/oppo-reno-10x-zoom-edition-black-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 5,
                HinhAnhSanPhamId = 14,
                ImagePath = "images/oppo-reno-10x-zoom-edition-den-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 5,
                HinhAnhSanPhamId = 15,
                ImagePath = "images/oppo-reno-10x-zoom-edition-den-3-org.jpg"
            });

            // OPPO A1K
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 6,
                HinhAnhSanPhamId = 16,
                ImagePath = "images/oppo-a1k-red-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 6,
                HinhAnhSanPhamId = 17,
                ImagePath = "images/oppo-a1k-do-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 6,
                HinhAnhSanPhamId = 18,
                ImagePath = "images/oppo-a1k-do-3-org.jpg"
            });

            // Huawei P30 Pro
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 7,
                HinhAnhSanPhamId = 19,
                ImagePath = "images/huawei-p30-pro-1-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 7,
                HinhAnhSanPhamId = 20,
                ImagePath = "images/huawei-p30-pro-xanh-duong-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 7,
                HinhAnhSanPhamId = 21,
                ImagePath = "images/huawei-p30-pro-xanh-duong-3-org.jpg"
            });

            // Huawei Y7 Pro (2019)
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 8,
                HinhAnhSanPhamId = 22,
                ImagePath = "images/huawei-y7-pro-2019-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 8,
                HinhAnhSanPhamId = 23,
                ImagePath = "images/huawei-y7-pro-2019-xanh-duong-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 8,
                HinhAnhSanPhamId = 24,
                ImagePath = "images/huawei-y7-pro-2019-xanh-duong-3-org.jpg"
            });

            // iPad Pro 11 inch Wifi 64GB (2018)
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 9,
                HinhAnhSanPhamId = 25,
                ImagePath = "images/ipad-pro-11-inch-2018-64gb-wifi-33397-chitiet-400x460.png"
            });

            // iPad Wifi 32GB (2018)
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 10,
                HinhAnhSanPhamId = 26,
                ImagePath = "images/ipad-6th-wifi-32gb-1-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 10,
                HinhAnhSanPhamId = 27,
                ImagePath = "images/ipad-wifi-32gb-2018-mau-bac-3-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 10,
                HinhAnhSanPhamId = 28,
                ImagePath = "images/ipad-wifi-32gb-2018-mau-bac-1-org.jpg"
            });

            // Samsung Galaxy Tab S6
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 11,
                HinhAnhSanPhamId = 29,
                ImagePath = "images/samsung-galaxy-tab-s6-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 11,
                HinhAnhSanPhamId = 30,
                ImagePath = "images/samsung-galaxy-tab-s6-xanh-duong-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 11,
                HinhAnhSanPhamId = 31,
                ImagePath = "images/samsung-galaxy-tab-s6-xanh-duong-3-org.jpg"
            });

            // Samsung Galaxy Tab A8 8" T295 (2019)
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 12,
                HinhAnhSanPhamId = 32,
                ImagePath = "images/samsung-galaxy-tab-a8-t295-2019-silver-400x460.png"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 12,
                HinhAnhSanPhamId = 33,
                ImagePath = "images/samsung-galaxy-tab-a8-t295-2019-bac-2-org.jpg"
            });
            context_.HinhAnhSanPhamContext.AddOrUpdate(new HinhAnhSanPham()
            {
                SanPhamId = 12,
                HinhAnhSanPhamId = 34,
                ImagePath = "images/samsung-galaxy-tab-a8-t295-2019-bac-3-org.jpg"
            });

            context_.SaveChanges();
        }
    }
}