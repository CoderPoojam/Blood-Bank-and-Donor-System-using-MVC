using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BloodProject.Models
{
    [Table("Donor")]
    public class Donor
    {

        [Key]
        public int Donor_id { get; set; }

        [Display(Name = "Name")]
        public string Donor_Name { get; set; }

        [Display(Name = "Email")]
        public string Donor_Email { get; set; }

        [Display(Name = "Mobile")]
        public string Donor_Mobile { get; set; }

        [Display(Name = "Blood_Group")]
        public string Donor_BloodGroup { get; set; }

        [Display(Name = "Address")]
        public string Donor_Address { get; set; }
    }
}