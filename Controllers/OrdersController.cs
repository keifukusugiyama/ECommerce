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
    public class OrdersController : Controller
    {
        private ECommerceContext dbContext;

        public OrdersController(ECommerceContext context)
        {
            dbContext = context;
        }
        
// ------------orders main page-------------
        [HttpGet("/orders")]
        public IActionResult Orders()
        {
            List<Order> allOrders = dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .ToList();
            ViewBag.allOrders = allOrders;

            List<Customer> allCustomers = dbContext.Customers.ToList();
            ViewBag.allCustomers = allCustomers;

            List<Product> allProducts = dbContext.Products.ToList();
            ViewBag.allProducts = allProducts;
            
            return View();
        }

// -----------adding new order------------
        [HttpPost("newOrder")]
        public IActionResult newOrder(Order newOrder)
        {
            // add new order
            dbContext.Add(newOrder);
            dbContext.SaveChanges();

            //update the product quantity with ordered qty
            Product UpdatingProduct = dbContext.Products
            .FirstOrDefault(p => p.ProductId == newOrder.ProductId);

            UpdatingProduct.Quantity -= newOrder.Quantity;
            UpdatingProduct.UpdatedAt = DateTime.Now;
            dbContext.SaveChanges();
        
            return RedirectToAction("Orders");
        }

// ----------------search feature---------------
        [HttpPost("/orders/search")]
        public IActionResult OrdersSearch(string keyword)
        {
            List<Order> resultOrders = dbContext.Orders
            .Include(o => o.Customer)
            .Include(o => o.Product)
            .Where(c => c.Customer.Name.Contains(keyword) || c.Product.Name.Contains(keyword))
            .ToList();

            ViewBag.allOrders = resultOrders;

            List<Customer> allCustomers = dbContext.Customers.ToList();
            ViewBag.allCustomers = allCustomers;

            List<Product> allProducts = dbContext.Products.ToList();
            ViewBag.allProducts = allProducts;
            
            return View("Orders");
        }

    }
}
