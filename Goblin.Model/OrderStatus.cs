using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    public class OrderStatus
    {

        [Key]
        public int OrderStatusId { get; set; }
        public string Status { get; set; }
        public bool Processed { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderItem> OrderItems { get;set; }
    }
}