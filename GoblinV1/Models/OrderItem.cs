using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class OrderItem
    {

        [Key]
        public int OrderItemsId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double? Price { get; set; }
        public string ItemName { get; set; }
        public string Specs { get; set; }

    }
}