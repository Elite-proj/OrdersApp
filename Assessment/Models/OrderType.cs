using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class OrderType
    {
        public int OrderTypeID { get; set; }
        public string TypeDescription { get; set; }
    }
}
