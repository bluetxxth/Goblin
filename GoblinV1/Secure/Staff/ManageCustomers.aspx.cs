using GoblinV1.Logic;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure.Staff
{
    public partial class ManageCustomers : System.Web.UI.Page
    {
        private EntityMappingContext ctx = new EntityMappingContext();

        protected void Page_Load(object sender, EventArgs e)
        {

            CustomerGridView.EnableDynamicData(typeof(Customer));
            //Bind product GridView
            CustomerGridView.DataSource = ctx.Customers.ToList<Customer>();
            CustomerGridView.DataBind();

        }


        /// <summary>
        /// Get product 
        /// </summary>
        public Customer SelectCustomer()
        {
            int customerId = (int)ViewState["CustomerId"];

            return ctx.Customers.Find(customerId);
        }

        public void InsertCustomer(Customer customer)
        {
            ctx.Customers.Add(customer);

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
                Response.Redirect("ManageCustomers.aspx");
            }


        }


        /// <summary>
        /// Behavior for product update
        /// </summary>
        /// <param name="productUpdated"></param>
        public void UpdateCustomer(Customer customerUpdated)
        {
            var customer = ctx.Customers.Find(customerUpdated.CustomerId);
            customer.FirstName = customerUpdated.FirstName;

            customer.FirstName = customerUpdated.FirstName;
            customer.MiddleName = customerUpdated.MiddleName;
            customer.LastName = customerUpdated.LastName;
            customer.Email = customerUpdated.Email;
            customer.Phone = customerUpdated.Phone;
            //customer.AddressId = customer.AddressId;

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
                Response.Redirect("Admin.aspx");
            }
        }
        /// <summary>
        /// Behavior for row deleting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CustomerGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int customerId = (int)e.Keys[0];
            var customer = ctx.Customers.Find(customerId);
            ctx.Customers.Remove(customer);
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
                Response.Redirect("Admin.aspx");
            }

        }

        /// <summary>
        /// Behavior for selected index changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CustomerGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["CustomerId"] = CustomerGridView.SelectedDataKey.Value;
            CustomerFormView.ChangeMode(FormViewMode.Edit);
        }
    }
}