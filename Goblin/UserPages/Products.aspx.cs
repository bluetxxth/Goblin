using Goblin.BLL;
using Goblin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goblin.UserPages
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Category> GetCategories()
        {
            var _db = new EntityMappingContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        }
    }
}