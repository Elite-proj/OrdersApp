using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class SearchOrderLineVM
    {
        [Required(ErrorMessage ="Please enter product code")]
        public string ProductCode { get; set; }
    }
}
