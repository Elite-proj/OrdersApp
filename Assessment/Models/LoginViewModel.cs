using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please enter email address.")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid format")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage ="Please enter password")]
        public string Password { get; set; }
    }
}
