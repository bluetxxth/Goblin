using GoblinV1.Logic;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoblinV1.Secure.Staff
{
    public partial class AddProduct : System.Web.UI.Page
    {

        AdminEngine m_adminEngine = new AdminEngine();

        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                lblAddStatus.Text = "Product added!";
            }

            if (productAction == "remove")
            {
                lblRemoveStatus.Text = "Product removed!";
            }
        }

        /// <summary>
        /// Behavior for adding product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddProductButton_Click(object sender, EventArgs e)
        {
            bool fileOK = false;

            String path = Server.MapPath("~/Catalog/Images/");
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    ProductImage.PostedFile.SaveAs(path + ProductImage.FileName);
                    // Save to Images/Thumbs folder.
                    ProductImage.PostedFile.SaveAs(path + "Thumbs/" + ProductImage.FileName);
                }
                catch (Exception ex)
                {
                    lblAddStatus.Text = ex.Message;
                }

                // Add product data to DB.

                bool addSuccess = m_adminEngine.AddProduct(AddProductName.Text, AddProductDescription.Text,
                    AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);
                if (addSuccess)
                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    lblAddStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                lblAddStatus.Text = "Unable to accept file type.";
            }
        }

        /// <summary>
        /// Get categories
        /// </summary>
        /// <returns></returns>
        public IQueryable GetCategories()
        {
            var ctx = new EntityMappingContext();
            IQueryable query = ctx.Categories;
            return query;
        }


        /// <summary>
        /// Get products
        /// </summary>
        /// <returns></returns>
        public IQueryable GetProducts()
        {
            var ctx = new EntityMappingContext();
            IQueryable query = ctx.Products;
            return query;
        }


        /// <summary>
        /// Behavior for remove product button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var ctx = new EntityMappingContext())
            {
                int productId = Convert.ToInt32(DropDownRemoveProduct.SelectedValue);
                var myItem = (from c in ctx.Products where c.ProductID == productId select c).FirstOrDefault();
                if (myItem != null)
                {
                    ctx.Products.Remove(myItem);
                    ctx.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    lblRemoveStatus.Text = "Unable to locate product.";
                }
            }
        }

    }
}