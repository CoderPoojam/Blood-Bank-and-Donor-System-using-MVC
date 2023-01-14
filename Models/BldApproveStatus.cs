using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BloodProject.Models
{
    [Table("BldApprovalStatus")]
    public class BldApproveStatus
    {

        [Key]
        public int ReqA_id { get; set; }

        [Display(Name = "Name")]
        public string ReqA_Name { get; set; }

        [Display(Name = "Email")]
        public string ReqA_Email { get; set; }

        [Display(Name = "Mobile")]
        public string ReqA_Mobile { get; set; }

        [Display(Name = "Blood_Group")]
        public string ReqA_BloodGroup { get; set; }

        [Display(Name = "Address")]
        public string ReqA_Address { get; set; }

        [Display(Name = "Status")]
        public string Bld_Approval_status { get; set; }
    }
}