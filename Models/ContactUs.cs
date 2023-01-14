using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BloodProject.Models
{
    [Table("ContactUs")]
    public class ContactUs
    {


        [Key]
        public int Cid { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Cname { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email Id")]
        public string CEmail { get; set; }

        [Required(ErrorMessage = "Please enter your subject related to your query")]
        [Display(Name = "Subject")]
        public string Csubject { get; set; }

        [Required(ErrorMessage = "Please enter your message")]
        [Display(Name = "Your Message")]
        public string CYourMsg { get; set; }
    }
}
