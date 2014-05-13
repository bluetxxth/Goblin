using Goblin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goblin.BLL
{
   public class OrderEngine
    {
        private EntityMappingContext ctx = new EntityMappingContext();


        /// <summary>
        /// Constructs an object of type OrderEngine
        /// </summary>
        public OrderEngine() { }

        public int LastOrderId { get; set; }

        public List<Order> GetOrder()
        {
            return ctx.Orders.Select(order => order).ToList();

        }

       /// <summary>
       /// get the order confirmations
       /// </summary>
       /// <returns></returns>
        public List<OrderConfirmation> GetOrderConfirmation()
        {
            return ctx.OrderConfirmations.Select(orderConfirmation => orderConfirmation).ToList();

        }


       /// <summary>
       /// Get the Order Items
       /// </summary>
       /// <returns></returns>
        public List<OrderItem> GetOrderItems()
        {
            return ctx.OrderItems.Select(orderItem => orderItem).ToList();
        }

       /// <summary>
       /// Get the Line Items
       /// </summary>
       /// <returns></returns>
        public List<LineItem> GetLineItems()
        {
            return ctx.LineItems.Select(lineItem => lineItem).ToList();
        }

    }
}
