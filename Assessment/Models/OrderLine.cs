using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
 
        public int LineNumber { get; set; }
        [Required(ErrorMessage ="Please enter product code")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage ="Please enter product cost price.")]
        public double ProductCostPrice { get; set; }
        [Required(ErrorMessage ="[lease enter Product Sales product.")]
        public double ProductSalePrice { get; set; }
        [Required(ErrorMessage ="Please enter quantity.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Select Product type")]
        public int ProductTypeID { get; set; }
        public ProductType ProductType { get; set; }

        [Required(ErrorMessage ="Please select order.")]
        public int OrdersID { get; set; }
        public Orders Orders { get; set; }

        public string DeleteStatus { get; set; }
    }
}
