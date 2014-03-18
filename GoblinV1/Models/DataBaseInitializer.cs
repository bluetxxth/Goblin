﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityMappingContext>
    {

        protected override void Seed(EntityMappingContext context)
        {

            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Hosting"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Dedicated Server"
                },

            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductID= 1,
                    ProductName = "Basic",
                    Specifications = "This is thought for users requiring a basic need who are not going to need to utilize a data-driven web application." + 
                                  "Perfect for personal needs", 
                    ProductImagePath="plan.png",
                    UnitPrice = 40,
                    CategoryId = 1
               },
                new Product 
                {
                    ProductID = 2,
                    ProductName = "Personal",
                    Specifications = "This is thought for for thos who need to send a larger volume of email but who do not require a database",
                    ProductImagePath="plan.png",
                    UnitPrice = 50,
                     CategoryId = 1
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Pro",
                    Specifications = "A plan with  data-driven web applications in mind for the small business needs",
                    ProductImagePath="plan.png",
                    UnitPrice = 70,
                    CategoryId = 1
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Dedicated",
                    Specifications = "Business grade hosting plan with reverse dns and full access to your pointer",
                    ProductImagePath="plan.png",
                    UnitPrice = 150,
                    CategoryId = 1
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "IBM Series 6000",
                    Specifications = "16 GB Memory DDR3, 6 Cores, Single Processor 4M Cache" + 
                                  "Expandable",
                    ProductImagePath="server.png",
                    UnitPrice = 250.50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "IBM Series 8000",
                    Specifications = "32 GB Memory DDR3, 12 Cores, Dual Processors 4M Cache",
                    ProductImagePath="server.png",
                    UnitPrice = 350.50,
                    CategoryId = 2
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "IBM Series 10000",
                    Specifications = "64GB Memory DDR3, 12 Cores, Dual Processors 8M Cache",
                    ProductImagePath="server.png",
                    UnitPrice = 1500,
                    CategoryId = 2
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "IBM Series XL",
                    Specifications = "120Gb Memory DDR3, 24Cores, Dual processors 16M Cache ",
                    ProductImagePath="server.png",
                    UnitPrice = 3000,
                    CategoryId = 2
                },
               
            };

            return products;
        }
    }
}