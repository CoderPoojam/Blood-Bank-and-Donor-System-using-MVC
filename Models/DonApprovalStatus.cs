using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BloodProject.Models
{
    [Table("DonApprovalStatus")]
    public class DonApprovalStatus
    {


        [Key]
        public int Donr_id { get; set; }

        [Display(Name = "Name")]
        public string Donr_Name { get; set; }

        [Display(Name = "Email")]
        public string Donr_Email { get; set; }

        [Display(Name = "Mobile")]
        public string Donr_Mobile { get; set; }

        [Display(Name = "Blood_Group")]
        public string Donr_BloodGroup { get; set; }

        [Display(Name = "Address")]
        public string Donr_Address { get; set; }

        [Display(Name = "DonAprStatus")]
        public string Don_Approval_status { get; set; }


    }
}
