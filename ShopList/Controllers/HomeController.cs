using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopList.Models;
using System.Linq;
using System.Collections.Generic;

namespace ShopList.Controllers
{
    public class HomeController : Controller
    {
        private ShopListContext db;

        public HomeController(ShopListContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Shops.ToList());
        }

        public IActionResult ShowProducts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowProducts(int? id)
        {
            List<Product> products = db.Products.Where(p => p.ShopId == id).ToList();
            if (products.Count == 0)
            {
                products.Add(new Product() { ShopId = (int)id });
            }

            return View(products);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Product product = db.Products.FirstOrDefault(p =>p.ProductId == id);
                if( product != null)
                {
                    return View(product);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Product product = db.Products.FirstOrDefault(p => p.ProductId == id);
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        [ActionName("Create")]
        public IActionResult ConfirmCreate(int? id)
        {
            if (id != null)
            {
                Product product = new Product() { ProductId = db.Products.Max(p => p.ProductId) + 1, ShopId = (int)id};
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
