
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using GoblinV1.Logic;
using GoblinV1.Models;
using System.Web.ModelBinding;
using System.Data.Entity.Validation;



namespace GoblinV1.UserPages
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        private string productName = null;
        ShoppingCartEngine shoppingCart = new ShoppingCartEngine();

        private EntityMappingContext ctx = new EntityMappingContext();

        Product product = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {

            GetTotals();

        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartEngine shoppingCart = new ShoppingCartEngine();



            return shoppingCart.GetCartItems();
        }


        public void  GetTotals()
        {
  
           string total = Convert.ToString(shoppingCart.GetTotal());

           lblTotal.Text = total;
        }


        public string GetName()
        {
            string productName = null;
            productName = shoppingCart.GetName();

            return productName;
        }


        public double  GetProductPrice()
        {
           int productId =  Convert.ToInt32(Session["productId"]);

           var product = ctx.Products.Find(productId);

          // int productCategory = Convert.ToInt32(product.Category);
          // int productStock = Convert.ToInt32(product.Stock);
          //string productName =  product.ProductName;
          //string productImagePath = product.ProductImagePath;
          //string productSpecs = product.Specifications;
          double productUnitPrice = Convert.ToDouble(product.UnitPrice);

          return productUnitPrice;
        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UserPages/Products.aspx");
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            EntityMappingContext ctx = new EntityMappingContext();

            OrderStatus orderstatus = ctx.OrderStatuses.Create();

    
            orderstatus.Status = "Created" + DateTime.Now.ToString();

            Response.Redirect("/UserPages/CreateUser.aspx");
            
             try
            {
                ctx.OrderStatuses.Add(orderstatus);
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


    }
}