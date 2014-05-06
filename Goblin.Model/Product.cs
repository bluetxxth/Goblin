using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Goblin.Model
{
    /// <summary>
    /// Class that represents a product
    /// </summary>
    public class Product
    {
          [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(150)]
        //[ExcludeChar("^[^<>.!@#%]+$")]
        public string ProductImagePath { get; set; }

         [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Specifications { get; set; }

        public string Options { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Invalid price")]
        //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? UnitPrice { get; set; }

        [Required(ErrorMessage = "Invalid category")]
        public int? CategoryId { get; set; }

        //[Required(ErrorMessage = "Enter category")]
        public virtual Category Category { get; set; }

        public int Stock { get; set; }
    }
}