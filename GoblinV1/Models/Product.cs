using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoblinV1.Models
{
    /// <summary>
    /// Class that represents a product
    /// </summary>
    public class Product
    {

        private int m_id = 0;
        private int m_qty = 0;
        private double m_price = 0;
        private ProductType m_productType = 0;
        private string m_productName = null;
        private string m_specifications = null;
        private string m_options = null;
        private bool m_inStock = false;


        /// <summary>
        /// Creates object of type product
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Creates object of type product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="qty"></param>
        /// <param name="price"></param>
        /// <param name="productType"></param>
        /// <param name="productName"></param>
        /// <param name="specifications"></param>
        /// <param name="options"></param>
        /// <param name="inStock"></param>
        public Product(int id, int qty, double price, ProductType productType,
                        string productName, string specifications, string options, bool inStock)
        {

            this.m_id = id;
            this.m_qty = qty;
            this.m_price = price;
            this.m_productType = productType;
            this.m_productName = productName;
            this.m_specifications = specifications;
            this.m_options = options;
            this.m_inStock = inStock;

        }

          [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(150)]
        public string ProductImagePath { get; set; }

         [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Specifications { get; set; }

        public string Options { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int Stock { get; set; }
    }
}