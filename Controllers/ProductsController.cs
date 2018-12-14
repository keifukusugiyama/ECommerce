using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private ECommerceContext dbContext;

        public ProductsController(ECommerceContext context)
        {
            dbContext = context;
        }

// -----------main products page-----------
        [HttpGet("/products")]
        public IActionResult Products()
        {
            List<Product> allProducts = dbContext.Products.ToList();

            ViewBag.allProducts = allProducts;
            return View();
        }
// -----------adding new product------------
        [HttpPost("newProduct")]
        public IActionResult newProduct(Product newProduct)
        {
            // Check initial ModelState
            if(ModelState.IsValid)
            {
                
                dbContext.Add(newProduct);
                dbContext.SaveChanges();
            
                return RedirectToAction("Products");
            }

            return View("Products");
        }
// ----------------search------------------
        [HttpPost("/products/search")]
        public IActionResult ProductsSearch(string keyword)
        {
            List<Product> resultProducts = dbContext.Products
            .Where(c => c.Name.Contains(keyword))
            .ToList();

            ViewBag.allProducts = resultProducts;
            return View("Products");
        }
    }
}

