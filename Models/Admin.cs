using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodProject.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Admin_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Email Id")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Admin_Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Admin_Password { get; set; }
    }
}
