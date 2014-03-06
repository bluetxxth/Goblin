
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class Order
    {

        
        [Key]
        public int OrderId { get; set; }
        public DateTime Created { get; set; }

        [Required( ErrorMessage= "No quantity specified")]
        public int Qty { get; set; }
        public string Description { get; set; }
       
        public double? Price { get; set; }
        public virtual Product Products { get; set; }
        public virtual ICollection <OrderStatus> Statuses { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual Address Address { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}