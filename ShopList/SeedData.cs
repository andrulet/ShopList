using System.Collections.Generic;
using System.Linq;
using ShopList.Models;

namespace ShopList
{
    public static class SeedData
    {        public static void Initialize(ShopListContext context)
        {
            Product[] products =
            {
                new Product { ProductName = "Samsung Galaxy S10 Lite", ProductDescription = "Android, экран 6.7', AMOLED (1080x2400), Qualcomm Snapdragon 855, ОЗУ 6 ГБ, флэш-память 128 ГБ, карты памяти, камера 48 Мп, аккумулятор 4500 мАч, 2 SIM" },
                new Product { ProductName = "Samsung Galaxy Z Fold3 5G", ProductDescription = "Android, экран 7.6', AMOLED (1768x2208), Qualcomm Snapdragon 888, ОЗУ 12 ГБ, флэш-память 512 ГБ, камера 12 Мп, аккумулятор 4400 мАч, 2 SIM" },
                new Product { ProductName = "Apple iPhone 13 Pro Max", ProductDescription = "Apple iOS, экран 6.7', OLED (1284x2778), Apple A15 Bionic, ОЗУ 6 ГБ, флэш-память 1 ТБ, камера 12 Мп, 1 SIM" },
                new Product { ProductName = "Samsung Galaxy Z Fold2 5G", ProductDescription = "Android, экран 7.6', AMOLED (1768x2208), Qualcomm Snapdragon 865+, ОЗУ 12 ГБ, флэш-память 512 ГБ, камера 12 Мп, аккумулятор 4500 мАч, 1 SIM" },
                new Product { ProductName = "Apple iPhone 13 Pro", ProductDescription = "Apple iOS, экран 6.1', OLED (1170x2532), Apple A15 Bionic, ОЗУ 6 ГБ, флэш-память 256 ГБ, камера 12 Мп, 1 SIM" },
                new Product { ProductName = "Apple iPhone 13 mini", ProductDescription = "Apple iOS, экран 5.4', OLED (1080x2340), Apple A15 Bionic, ОЗУ 4 ГБ, флэш-память 512 ГБ, камера 12 Мп, 1 SIM" },
                new Product { ProductName = "Samsung Galaxy S20 Ultra 5G", ProductDescription = "Android, экран 6.9', AMOLED (1440x3200), Qualcomm Snapdragon 865, ОЗУ 16 ГБ, флэш-память 512 ГБ, карты памяти, камера 108 Мп, аккумулятор 5000 мАч, 2 SIM" },
                new Product { ProductName = "Смартфон Samsung Galaxy S21 Ultra", ProductDescription = "Android, экран 6.8', AMOLED (1440x3200), Qualcomm Snapdragon 888, ОЗУ 16 ГБ, флэш-память 512 ГБ, камера 108 Мп, аккумулятор 5000 мАч, 2 SIM" },
            };

            if (!context.Products.Any())
            {
                context.Products.AddRange(products);
            }
            
            if (!context.Shops.Any())
            {                
                context.Shops.AddRange(new Shop[]
                    {
                        new Shop { ShopName = "AMD", ShopAdress = "Minsk", OpeningTime = "10:00 - 18:00", Products = new List<Product>() { products[0], products[1], products[2] } },
                        new Shop { ShopName = "KST", ShopAdress = "Minsk", OpeningTime = "10:00 - 17:00", Products = new List<Product>() { products[3], products[4], products[5] }},
                        new Shop { ShopName = "5Element", ShopAdress = "Minsk", OpeningTime = "10:00 - 19:00", Products = new List<Product>() { products[6], products[7] }},                        
                    });
            }
            context.SaveChanges();
        }
    }
}
