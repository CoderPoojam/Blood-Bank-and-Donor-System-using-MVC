using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace BloodProject.Models
{
    public class BloodsDatabaseEntities : DbContext
    {
        public BloodsDatabaseEntities()
            : base("name=BloodsDatabaseEntities")
        {

        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BloodStock> BloodStocks { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Requester> Requesters { get; set; }
        public virtual DbSet<BldApproveStatus> BldApprovalStatuses { get; set; }
        public virtual DbSet<DonApprovalStatus> DonApprovalStatuses { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }

    }
}