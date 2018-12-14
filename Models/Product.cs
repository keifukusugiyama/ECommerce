using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ECommerce.Models
{
    public class Product
    {
        [Key] 
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity  { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Order> ProdOrders { get; set; }
    }
}
