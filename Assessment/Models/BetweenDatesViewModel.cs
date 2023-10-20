using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class BetweenDatesViewModel
    {
        [Required(ErrorMessage ="Please select minimum date.")]
        public DateTime MinDate { get; set; }
        [Required(ErrorMessage = "Please select maximum date.")]
        public  DateTime MaxDate { get; set; }

    }
}
