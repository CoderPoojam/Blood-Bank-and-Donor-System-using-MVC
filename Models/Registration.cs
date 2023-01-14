using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BloodProject.Models
{
    [Table("Registration")]
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Your Email")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please Enter the Valid Email-ID")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Mobile Number")]
        // [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter 10 Digit Mobile Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-, ]?([0-9]{3})[-, ]?([0-9]{4})$", ErrorMessage = "Please Enter valid mobile number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please Enter Your Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Enter Your Age")]
        [Range(20, 60, ErrorMessage = "Age Must Be Between 20-60 in Years.")]
        public int Age { get; set; }


        [Display(Name = "Blood Group")]
        [Required(ErrorMessage = "Please Enter Your Blood Group")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Please Enter Your Weight")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Please Enter Your Height")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Please Enter The Password")]
        [DataType(DataType.Password)]
        //[StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?-.*\d)).+$")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]

        public string Password { get; set; }

        [Required]
        //[StringLength(18,ErrorMessage ="The {0} must be at least {2} characters long.",MinimumLength =4)]
        //[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?-.*\d)).+$")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm Password does not match, type again")]


        public string CPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address.")]
        [StringLength(200, MinimumLength = 3)]
        public string Address { get; set; }
    }
}