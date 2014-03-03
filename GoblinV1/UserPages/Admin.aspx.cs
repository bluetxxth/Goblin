using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoblinV1.Models;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace GoblinV1.UserPages
{
    public partial class Admin : System.Web.UI.Page
    {
        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            ProductGridView.DataSource = ctx.Products.ToList<Product>();


            try
            {
                ProductGridView.DataBind();

            }catch(HttpException ex){

                Session["Error"] = ex;
                Response.Redirect("/UserPages/ErrorPage.aspx");

            }

           
        }

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


                //foreach (var eve in ex.EntityValidationErrors)
                //{
                //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //            ve.PropertyName, ve.ErrorMessage);
                //    }
                //}
           
            }
        }

      

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


            if(product.ProductId == 0)
            {
                ctx.Products.Add(product);

                try
                {
                    ctx.SaveChanges();
                    Response.Redirect("/UserPages/TestPage.aspx");
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

                    Response.Redirect("/UserPages/TestPage.aspx");

                    // Throw a new DbEntityValidationException with the improved exception message.
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
            }
        }



    }
}