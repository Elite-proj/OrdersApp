using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class Orders
    {
        public int OrdersID { get; set; }
        [Required(ErrorMessage ="Please enter Order number.")]
        public int OrderNumber { get; set; }
        [Required(ErrorMessage ="Please enter customer name.")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage ="Please select date of creation.")]
        public DateTime CreatedDate { get; set; }
        [Required( ErrorMessage ="Please select order type")]
        public int OrderTypeID { get; set; }
        public OrderType OrderType { get; set; }
        [Required(ErrorMessage ="Please select order status")]
        public int OrderStatusID { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public string DeleteStatus { get; set; }

    }
}
