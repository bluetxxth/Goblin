using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoblinV1.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;
using GoblinV1.Logic;

namespace GoblinV1.UserPages
{
    public partial class Admin : System.Web.UI.Page
    {
        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Bind product GridView
            ProductGridView.DataSource = ctx.Products.ToList<Product>();

            try
            {
                ProductGridView.DataBind();

            }catch(HttpException ex){

                Session["Error"] = ex;
                Response.Redirect("/UserPages/ErrorPage.aspx");
            }

            ////Bind OrderGridView
            //OrderGridView.DataSource = ctx.Orders.ToList<Order>();

            //try
            //{
            //    OrderGridView.DataBind();

            //}
            //catch (HttpException ex)
            //{

            //    Session["Error"] = ex;
            //    Response.Redirect("/UserPages/ErrorPage.aspx");
            //}

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

        /// <summary>
        /// Behavior for gridview 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProductGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int productId = (int)ProductGridView.SelectedDataKey.Value;

            var product = ctx.Products.Find(productId);

            //place data from database on the page
            txtProductImagePath.Text = product.ProductImagePath;
            txtProductName.Text = product.ProductName;
            txtProductSpecs.Text = product.Specifications;
            txtProductOptions.Text = product.Options;
            txtProductPrice.Text = product.UnitPrice.ToString();
            txtCategory.Text = product.Category.ToString();
            txtProductStock.Text = product.Stock.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Product product = ctx.Products.Create();

            product.ProductName = txtProductName.Text;
            product.Specifications = txtProductSpecs.Text;
            product.Options = txtProductOptions.Text;
            product.ProductImagePath = txtProductImagePath.Text;
            product.CategoryId = Convert.ToInt32 (txtCategory.Text);

            product.UnitPrice = Convert.ToDouble(txtProductPrice.Text);

            double price;

            Double.TryParse(txtProductPrice.Text, out price);

            product.UnitPrice = price;

            product.Stock = Convert.ToInt32(txtProductStock.Text);


            try
            {
                ctx.Products.Add(product);
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

                Response.Redirect("/UserPages/ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //set UserID to 0 if no user selected
            int productId = (ProductGridView.SelectedDataKey == null ? 0 : (int)ProductGridView.SelectedDataKey.Value);

            Product product = (productId == 0) ? 
                new Product(): //new product
                ctx.Products.Find(productId); //modify older user, retrieve the user state from database

            product.ProductImagePath = txtProductImagePath.Text;
            product.ProductName =  txtProductName.Text;
            product.Specifications = txtProductSpecs.Text;
            product.UnitPrice = Convert.ToDouble(txtProductPrice.Text);
            product.CategoryId = Convert.ToInt32(txtCategory.Text);
            product.Stock = Convert.ToInt32(txtProductStock.Text);


            if(product.ProductID == 0)
            {
                ctx.Products.Add(product);

                try
                {
                    ctx.SaveChanges();
                    Response.Redirect("/UserPages/ErrorPage.aspx");
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

                    Response.Redirect("/UserPages/ErrorPage.aspx");

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
        }


        /// <summary>
        /// Provide behavior for deleting row from gridview
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

                Response.Redirect("/UserPages/ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cboxProcessed_CheckedChanged(object sender, EventArgs e)
        {

            //CheckBox chk = (CheckBox)sender;
            //GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            ////lblmsg.Text = OrderGridView.DataKeys[gr.RowIndex].Value.ToString();

            var rowIndex = ((GridViewRow)((Control)sender).NamingContainer).RowIndex +1;

    
        

                        //Change the status or the order
            var order = (from myorder in ctx.Orders
                         where myorder.OrderId == rowIndex // get the corresponding order
                         select myorder).First();  // this will fetch the record.

            order.Processed = DateTime.Now.ToString();
            order.IsProcessed = true;


            //Session["Error"] = rowIndex;
            //Response.Redirect("/UserPages/ErrorPage.aspx");

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

                Response.Redirect("/UserPages/ErrorPage.aspx");

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            finally
            {
                Response.Redirect("/UserPages/Admin.aspx");
            }
        }
    }
}