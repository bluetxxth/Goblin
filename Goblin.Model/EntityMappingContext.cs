using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Goblin.Model
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

        static EntityMappingContext() { Database.SetInitializer<EntityMappingContext>(new DataBaseInitializer()); }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Shippment> Shipments { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Department> Departments { get; set;}
        public DbSet<OrderConfirmation> OrderConfirmations { get; set; }
       public DbSet<LineItem> LineItems {get; set;}

    }
}