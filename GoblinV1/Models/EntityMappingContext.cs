using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    /// <summary>
    /// This class provides for columns for the database.
    /// </summary>
    public class EntityMappingContext: DbContext
    {
        /// <summary>
        /// Create ab object of type EntityMappingContext
        /// </summary>
        public EntityMappingContext() : base("DefaultConnection") { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Invoice> Invoices { get; set; }
        //public DbSet<Shippment> Shipments { get; set; }
  





    }
}