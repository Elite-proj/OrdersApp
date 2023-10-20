﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Assessment.Models
{
    public class AppUsers
    {
        public int AppUsersID { get; set; }
        [Required(ErrorMessage ="Please enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please enter your last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter your Email")]
        [EmailAddress(ErrorMessage ="Incorrect email address")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid format")]
        [Compare("ConfirmEmail")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage ="Please confirm email address")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid format")]
        [Display(Name ="Confirm email")]
        public string ConfirmEmail { get; set; }

        [Required(ErrorMessage ="Please enter password")]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Please confirm password")]
        [Compare("ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Please select user role.")]
        public int UserRoleID { get; set; }
        public UserRole UserRole { get; set; }
    }
}
