﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoblinV1.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Goblin.BLL;
using Goblin.Model;


namespace Goblin.UserPages
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            ProductGridView.EnableDynamicData(typeof(Product));
            //Bind product GridView
            ProductGridView.DataSource = ctx.Products.ToList<Product>();
            ProductGridView.DataBind();
        }

        /// <summary>
        /// Get product 
        /// </summary>
        public Product SelectProduct()
        {
            int productId = (int)ViewState["ProductId"];

            return ctx.Products.Find(productId);
        }

        public void InsertProduct(Product product)
        {
            ctx.Products.Add(product);

            try
            {

                ctx.SaveChanges();
                //validate
                ctx.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                  .SelectMany(x => x.ValidationErrors)
                  .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                Session["ValidationError"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("Secure/Staff/ManageProducts.aspx");
            }


        }


        /// <summary>
        /// Behavior for product update
        /// </summary>
        /// <param name="productUpdated"></param>
        public void UpdateProduct(Product productUpdated)
        {
            var product = ctx.Products.Find(productUpdated.ProductID);
            product.ProductName = productUpdated.ProductName;

            product.ProductImagePath = productUpdated.ProductImagePath;
            product.UnitPrice = productUpdated.UnitPrice;
            product.Options = productUpdated.Options;
            product.CategoryId = productUpdated.CategoryId;
            product.Stock = productUpdated.Stock;

            try
            {

                ctx.SaveChanges();
                //validate
                ctx.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (DbEntityValidationException ex)
            {


                var errorMessages = ex.EntityValidationErrors
                  .SelectMany(x => x.ValidationErrors)
                  .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                Session["Error"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("ManageProducts.aspx");
            }
        }
        /// <summary>
        /// Behavior for row deleting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProductGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int productId = (int)e.Keys[0];
            var product = ctx.Products.Find(productId);
            ctx.Products.Remove(product);
            try
            {

                ctx.SaveChanges();
                //validate
                ctx.Configuration.ValidateOnSaveEnabled = true;
            }
            catch (DbEntityValidationException ex)
            {

                var errorMessages = ex.EntityValidationErrors
                  .SelectMany(x => x.ValidationErrors)
                  .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                Session["Error"] = fullErrorMessage;

                Response.Redirect("ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("ManageProducts.aspx");
            }

        }

        /// <summary>
        /// Behavior for selected index changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProductGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["ProductId"] = ProductGridView.SelectedDataKey.Value;
            ProductFormView.ChangeMode(FormViewMode.Edit);
        }



        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrders()
        {
            OrderEngine orderEngine = new OrderEngine();
            return orderEngine.GetOrder();
        }

    }
}

