using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoblinV1.Logic
{
    public class OrderEngine
    {

        private EntityMappingContext ctx = new EntityMappingContext();
  

        /// <summary>
        /// Constructs an object of type OrderEngine
        /// </summary>
        public OrderEngine(){}

        public int LastOrderId { get; set; }

        public List<Order> GetOrder()
        {
           return ctx.Orders.Select(order => order).ToList();

        }




    }
}