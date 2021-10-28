using System.Collections.Generic;

namespace ShopList.Models
{
    public class Shop
    {        
        public int ShopId { get; set; }

        public string ShopName { get; set; }

        public string ShopAdress { get; set; }

        public string OpeningTime { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
