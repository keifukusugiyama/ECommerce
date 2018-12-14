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
    public class CustomersController : Controller
    {
        private ECommerceContext dbContext;

        public CustomersController(ECommerceContext context)
        {
            dbContext = context;
        }

// -----------main customers page-----------
        [HttpGet("/customers")]
        public IActionResult Customers()
        {
            List<Customer> allCustomers = dbContext.Customers.ToList();

            ViewBag.allCustomers = allCustomers;
            return View();
        }

// -----------adding new customer------------
        [HttpPost("newCustomer")]
        public IActionResult newCustomer(Customer newCustomer)
        {
            // Check initial ModelState
            if(ModelState.IsValid)
            {
            
                if(dbContext.Customers.Any(c => c.Name == newCustomer.Name))
                {
                    ModelState.AddModelError("Name", "Name already in use!");
                    
                    return View("Customers");
                }
                
                dbContext.Add(newCustomer);
                dbContext.SaveChanges();
            
                return RedirectToAction("Customers");
            }

            return View("Customers");
        }
// -----------------------------------------
        [HttpPost("/customers/search")]
        public IActionResult CustomersSearch(string keyword)
        {
            List<Customer> resultCustomers = dbContext.Customers
            .Where(c => c.Name.Contains(keyword))
            .ToList();

            ViewBag.allCustomers = resultCustomers;
            return View("Customers");
        }

// -----------------------------------------
        [HttpGet("/customers/remove/{id}")]
        public IActionResult deleteCustomer(int id)
        {
            Customer deletingCustomer = dbContext.Customers
            .Where(c => c.CustomerId == id)
            .FirstOrDefault();

            dbContext.Customers.Remove(deletingCustomer);
            dbContext.SaveChanges();

            return RedirectToAction("Customers");
        }
    }
}
