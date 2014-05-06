
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<EntityMappingContext>
    {

        protected override void Seed(EntityMappingContext context)
        {
            //seed categories
            GetCategories().ForEach(c => context.Categories.Add(c));
            //seed products
            GetProducts().ForEach(p => context.Products.Add(p));
            //seed departments
            GetDepartments().ForEach(d => context.Departments.Add(d));      

        }


        /// <summary>
        /// Populate categories
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Populate products
        /// </summary>
        /// <returns></returns>
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
                    CategoryId = 1,
                    Stock = 20
               },
                new Product 
                {
                    ProductID = 2,
                    ProductName = "Personal",
                    Specifications = "This is thought for for thos who need to send a larger volume of email but who do not require a database",
                    ProductImagePath="plan.png",
                    UnitPrice = 50,
                     CategoryId = 1,
                     Stock = 20
               },
                new Product
                {
                    ProductID = 3,
                    ProductName = "Pro",
                    Specifications = "A plan with  data-driven web applications in mind for the small business needs",
                    ProductImagePath="plan.png",
                    UnitPrice = 70,
                    CategoryId = 1,
                      Stock = 2
                },
                new Product
                {
                    ProductID = 4,
                    ProductName = "Dedicated",
                    Specifications = "Business grade hosting plan with reverse dns and full access to your pointer",
                    ProductImagePath="plan.png",
                    UnitPrice = 150,
                    CategoryId = 1,
                    Stock = 28
                },
                new Product
                {
                    ProductID = 5,
                    ProductName = "IBM Series 6000",
                    Specifications = "16 GB Memory DDR3, 6 Cores, Single Processor 4M Cache" + 
                                  "Expandable",
                    ProductImagePath="server.png",
                    UnitPrice = 250.50,
                    CategoryId = 2,
                      Stock = 5
                },
                new Product
                {
                    ProductID = 6,
                    ProductName = "IBM Series 8000",
                    Specifications = "32 GB Memory DDR3, 12 Cores, Dual Processors 4M Cache",
                    ProductImagePath="server.png",
                    UnitPrice = 350.50,
                    CategoryId = 2,
                },
                new Product
                {
                    ProductID = 7,
                    ProductName = "IBM Series 10000",
                    Specifications = "64GB Memory DDR3, 12 Cores, Dual Processors 8M Cache",
                    ProductImagePath="server.png",
                    UnitPrice = 1500,
                    CategoryId = 2,
                      Stock = 3
                },
                new Product
                {
                    ProductID = 8,
                    ProductName = "IBM Series XL",
                    Specifications = "120Gb Memory DDR3, 24Cores, Dual processors 16M Cache ",
                    ProductImagePath="server.png",
                    UnitPrice = 3000,
                    CategoryId = 2,
                      Stock = 2,
                },
               
            };

            return products;
        }

        /// <summary>
        /// Populate departments
        /// </summary>
        /// <returns></returns>
        private static List<Department> GetDepartments()
        {


            var department = new List<Department> {

                new Department
                {
                    DepartmentId= 1,
                    DepartmentName = "Administration",
                    DepartmentDescription ="Administer employees",
                    DepartmentUrl = "/ManagerRoles/Default.aspx",
                    DepartmentIcon = "department.jpg",
               },


                new Department
                {
                    DepartmentId= 2,
                    DepartmentName = "Logistics",
                    DepartmentDescription ="Shipments handling",
                    DepartmentUrl = "/ManagerLogistics/Logistics.aspx",
                    DepartmentIcon = "department.jpg",

               },

                new Department
                {
                    DepartmentId= 3,
                    DepartmentName = "Manage Products",
                    DepartmentDescription ="Manage products",
                    DepartmentUrl = "/ManagerProducts/Default.aspx",
                    DepartmentIcon = "department.jpg",

               },

                new Department
                {
                    DepartmentId= 4,
                    DepartmentName = "Proces Orders",
                    DepartmentDescription ="Process orders",
                    DepartmentUrl = "/ManagerLogistics/ProcessOrders.aspx",
                    DepartmentIcon = "department.jpg",

               },

                 new Department
                {
                    DepartmentId= 5,
                    DepartmentName = "Manage Users",
                    DepartmentDescription ="Administer users",
                    DepartmentUrl = "/ManagerCustomer/ManageCustomers.aspx",
                    DepartmentIcon = "department.jpg",
               },


                new Department
                {
                    DepartmentId= 6,
                    DepartmentName = "Revenue Tracker",
                    DepartmentDescription ="Administer users",
                    DepartmentUrl = "/ManagerRevenue/RevenueTracker.aspx",
                    DepartmentIcon = "department.jpg",
               },

            };

            return department;
        }
    }
}