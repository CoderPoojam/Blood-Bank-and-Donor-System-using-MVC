using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BloodProject.Models;

namespace BloodProject.Controllers
{
    public class AdminPageController : Controller
    {

        BloodsDatabaseEntities db = new BloodsDatabaseEntities();
        // GET: AdminPage
        [HttpGet]
        public ActionResult AdminLogin()
        {

            return View();
        }

        [HttpPost]

        public ActionResult AdminLogin(Admin model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var context = new BloodsDatabaseEntities())
                    {
                        bool isValid = context.Admins.Any(x => x.Admin_Email == model.Admin_Email && x.Admin_Password == model.Admin_Password);
                        if (isValid)
                        {
                            FormsAuthentication.SetAuthCookie(model.Admin_Email, false);
                            return RedirectToAction("AdminMainPage", "AdminPage");//HERE WE CAN CHANGE INTO ADMIN OR USER LOGIN PAGE
                        }
                        ModelState.AddModelError("", "Invalid Email or Password");
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
        [Authorize]
        public ActionResult AdminMainPage()
        {
            return View();
        }
        [Authorize]
        public ActionResult ViewBloodRequest()
        {
            List<Requester> DonorR = db.Requesters.ToList<Requester>();
            return View(DonorR);
        }
        [Authorize]
        public ActionResult ViewDonationRequest()
        {
            List<Donor> DonorR = db.Donors.ToList<Donor>();
            return View(DonorR);
        }


        public ActionResult Approve(int id)
        {
            Requester e = db.Requesters.Where(x => x.Requester_id == id).FirstOrDefault();
            var apr = new BldApproveStatus { ReqA_id = e.Requester_id, ReqA_Name = e.Requester_Name, ReqA_Email = e.Requester_Email, ReqA_Mobile = e.Requester_Mobile, ReqA_BloodGroup = e.Requester_BloodGroup, ReqA_Address = e.Requester_Address, Bld_Approval_status = " Request Approved" };
            using (var context = new BloodsDatabaseEntities())
            {
                context.BldApprovalStatuses.Add(apr);
                context.SaveChanges();
            }

            return View();
        }
        public ActionResult Reject(int id)
        {
            Requester e = db.Requesters.Where(x => x.Requester_id == id).FirstOrDefault();
            var apr = new BldApproveStatus { ReqA_id = e.Requester_id, ReqA_Name = e.Requester_Name, ReqA_Email = e.Requester_Email, ReqA_Mobile = e.Requester_Mobile, ReqA_BloodGroup = e.Requester_BloodGroup, ReqA_Address = e.Requester_Address, Bld_Approval_status = " Request Rejected" };
            using (var context = new BloodsDatabaseEntities())
            {
                context.BldApprovalStatuses.Add(apr);
                context.SaveChanges();
            }

            return View();
        }
        public ActionResult DonApprove(int id)
        {
            Donor e = db.Donors.Where(x => x.Donor_id == id).FirstOrDefault();
            var apr = new DonApprovalStatus { Donr_id = e.Donor_id, Donr_Name = e.Donor_Name, Donr_Email = e.Donor_Email, Donr_Mobile = e.Donor_Mobile, Donr_BloodGroup = e.Donor_BloodGroup, Donr_Address = e.Donor_Address, Don_Approval_status = " Request Approved" };
            using (var context = new BloodsDatabaseEntities())
            {
                context.DonApprovalStatuses.Add(apr);
                context.SaveChanges();
            }

            return View();
        }
        public ActionResult DonReject(int id)
        {
            Donor e = db.Donors.Where(x => x.Donor_id == id).FirstOrDefault();
            var apr = new DonApprovalStatus { Donr_id = e.Donor_id, Donr_Name = e.Donor_Name, Donr_Email = e.Donor_Email, Donr_Mobile = e.Donor_Mobile, Donr_BloodGroup = e.Donor_BloodGroup, Donr_Address = e.Donor_Address, Don_Approval_status = " Request Rejected" };

            using (var context = new BloodsDatabaseEntities())
            {
                context.DonApprovalStatuses.Add(apr);
                context.SaveChanges();
            }

            return View();
        }





        public ActionResult Admin(BloodStock obj)
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(BloodStock model)
        {
            BloodStock obj = new BloodStock();
            obj.BloodGroup = model.BloodGroup;
            obj.AvailableStock = model.AvailableStock;
            db.BloodStocks.Add(obj);
            db.SaveChanges();
            return View();
        }
        public ActionResult Add(BloodStock model)
        {
            if (ModelState.IsValid)
            {
                BloodStock obj = new BloodStock();
                obj.BloodStockId = model.BloodStockId;
                obj.BloodGroup = model.BloodGroup;
                obj.AvailableStock = model.AvailableStock;
                if (model.BloodStockId == 0)
                {

                    db.BloodStocks.Add(obj);
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            ModelState.Clear();
            return View("Admin");
        }

        public ActionResult AdminList()
        {
            var res = db.BloodStocks.ToList();
            return View(res);
        }

        public ActionResult Index()
        {
            List<ContactUs> contactus = db.ContactUs.ToList();
            return View(contactus);
        }

        public ActionResult Queries(int id)
        {
            try
            {
                var cs = db.ContactUs.Where(x => x.Cid == id).FirstOrDefault();
                db.ContactUs.Remove(cs);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


    }

}
