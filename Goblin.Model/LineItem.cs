using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goblin.Model
{
  public  class LineItem
    {
        [Key]
        public int LineItemId { get; set; }
        public int OrderId { get; set; }
        public string Added { get; set; }
        public string UserName { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public bool IsAdded { get; set; }
    }
}
