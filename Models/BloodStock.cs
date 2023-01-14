using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BloodProject.Models
{
    [Table("BloodStock")]
    public class BloodStock
    {
        [Key]
        public int BloodStockId { get; set; }
        public string BloodGroup { get; set; }
        public double AvailableStock { get; set; }
    }
}