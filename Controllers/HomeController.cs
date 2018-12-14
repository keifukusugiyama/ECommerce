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
    public class HomeController : Controller
    {
        private ECommerceContext dbContext;

        public HomeController(ECommerceContext context)
        {
            dbContext = context;
        }
        
        [HttpGet("/")]
        public IActionResult Index()
        {
            List<Product> allProducts = dbContext.Products
            .Take(5)
            .ToList();
            ViewBag.allProducts = allProducts;
            
            List<Order> allOrders = dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .OrderByDescending(o => o.CreatedAt)
            .Take(3)
            .ToList();
            ViewBag.allOrders = allOrders;

            List<Customer> allCustomers = dbContext.Customers
            .OrderByDescending(c => c.CreatedAt)
            .Take(3)
            .ToList();
            ViewBag.allCustomers = allCustomers;


            return View();
        }

    }
}
