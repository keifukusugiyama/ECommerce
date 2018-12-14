using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ECommerce.Models
{
    public class Customer
    {
        [Key] 
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Order> CustOrders { get; set; }
    }
}
