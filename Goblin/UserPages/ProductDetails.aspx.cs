﻿using Goblin.Model;
using GoblinV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goblin.UserPages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new EntityMappingContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(product => product.ProductID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}