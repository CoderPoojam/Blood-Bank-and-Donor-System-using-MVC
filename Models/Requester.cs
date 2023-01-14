using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BloodProject.Models
{
    [Table("Requester")]
    public class Requester
    {
        [Key]
        public int Requester_id { get; set; }

        [Display(Name = "Name")]
        public string Requester_Name { get; set; }

        [Display(Name = "Email")]
        public string Requester_Email { get; set; }

        [Display(Name = "Mobile")]
        public string Requester_Mobile { get; set; }

        [Display(Name = "Blood_Group")]
        public string Requester_BloodGroup { get; set; }

        [Display(Name = "Address")]
        public string Requester_Address { get; set; }



    }
}
