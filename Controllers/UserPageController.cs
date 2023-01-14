using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BloodProject.Models;
using BloodProject.Security;

namespace BloodProject.Controllers
{
    public class UserPageController : Controller
    {
        BloodsDatabaseEntities db = new BloodsDatabaseEntities();
        // GET: UserPage
        [Authorize]
        public ActionResult UserMainPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewBloodStock()
        {
            List<BloodStock> BloodS = db.BloodStocks.ToList<BloodStock>();
            return View(BloodS);
        }
        public ActionResult searchDonor(string searchBy, string search)
        {

            if (searchBy == "Address")
            {
                //  return View(db.Donors.Where(x => x.Donor_Address == search).ToList());
                //DonApprovalStatus don = new DonApprovalStatus();
                //    var don = db.BldApprovalStatuses.Where(x => x.Bld_Approval_status == "Request Approved");
                return View(db.DonApprovalStatuses.Where(x => x.Donr_Address == search && x.Don_Approval_status == " Request Approved").ToList());
            }
            else
            {
                //  return View(db.Donors.Where(x => x.Donor_BloodGroup == search).ToList());
                return View(db.DonApprovalStatuses.Where(x => x.Donr_BloodGroup == search && x.Don_Approval_status == " Request Approved").ToList());

            }

        }


        [HttpGet]
        public ActionResult RequestForDonation()
        {

            if (TempData["d"] != null)
            {
                string name = TempData["a"].ToString();
                string mail = TempData["b"].ToString();
                string mobile = TempData["c"].ToString();
                string bloodgroup = TempData["d"].ToString();
                string address = TempData["e"].ToString();

                ViewBag.f = name;
                ViewBag.g = mail;
                ViewBag.h = mobile;
                ViewBag.i = bloodgroup;
                ViewBag.j = address;
                TempData.Keep();
            }

            return View();
        }

        [HttpPost]
        public ActionResult RequestForDonation(Registration model)
        {



            if (db.Donors.Any(x => x.Donor_Email == model.Email))
            {


                ViewBag.Mes = "Request is already placed using this Email Kindly use another email and Do request";
                return View();

            }
            else
            {
                var donor = new Donor { Donor_Name = model.Name, Donor_Email = model.Email, Donor_Mobile = model.Mobile, Donor_BloodGroup = model.BloodGroup, Donor_Address = model.Address };

                using (var context = new BloodsDatabaseEntities())
                {
                    context.Donors.Add(donor);
                    context.SaveChanges();
                }
                //}
                ViewBag.Mes = "Your Request Added Succesfully";
                return View();
            }


        }



        [HttpGet]
        public ActionResult RequestForBlood()
        {

            if (TempData["d"] != null)
            {
                string name = TempData["a"].ToString();
                string mail = TempData["b"].ToString();
                string mobile = TempData["c"].ToString();
                string bloodgroup = TempData["d"].ToString();
                string address = TempData["e"].ToString();

                ViewBag.f = name;
                ViewBag.g = mail;
                ViewBag.h = mobile;
                ViewBag.i = bloodgroup;
                ViewBag.j = address;
                TempData.Keep();

            }
            return View();


        }

        [HttpPost]
        public ActionResult RequestForBlood(Registration model)
        {

            if (db.Requesters.Any(x => x.Requester_Email == model.Email))
            {
                ViewBag.Mes = "Request is already placed using this Email Kindly use another email and Do request";
                return View();

            }
            else
            {
                var req = new Requester { Requester_Name = model.Name, Requester_Email = model.Email, Requester_Mobile = model.Mobile, Requester_BloodGroup = model.BloodGroup, Requester_Address = model.Address };
                using (var context = new BloodsDatabaseEntities())
                {
                    context.Requesters.Add(req);
                    context.SaveChanges();
                }

                ViewBag.Mes = "Your Request Added Succesfully";
                return View();
            }

        }
        public ActionResult ApprovalStatus()
        {

            return View();
        }
        [HttpGet]
        public ActionResult AprStaReqBld()
        {
            if (TempData["d"] != null)
            {
                string nm = TempData["a"].ToString();
                string mil = TempData["b"].ToString();
                string mbl = TempData["c"].ToString();
                string bg = TempData["d"].ToString();
                string ad = TempData["e"].ToString();

                ViewBag.f = nm;
                ViewBag.g = mil;
                ViewBag.h = mbl;
                ViewBag.i = bg;
                ViewBag.j = ad;
                TempData.Keep();
            }

            return View();
        }
        [HttpPost]
        public ActionResult AprStaReqBld(Registration model)
        {
            try
            {


                Requester R = db.Requesters.Where(x => x.Requester_Email == model.Email).FirstOrDefault();
                if (R != null)
                {
                    BldApproveStatus e = db.BldApprovalStatuses.Where(x => x.ReqA_Email == model.Email).FirstOrDefault();

                    if (e == null)
                    {
                        ViewBag.s = "Request is yet to approve";
                    }
                    else
                    {
                        var status = e.Bld_Approval_status;
                        ViewBag.s = status;

                    }

                }
                else
                {
                    ViewBag.s = "No Pending requests";
                }

                return View();
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult AprStaReqDon()
        {
            if (TempData["d"] != null)
            {
                string nm = TempData["a"].ToString();
                string mil = TempData["b"].ToString();
                string mbl = TempData["c"].ToString();
                string bg = TempData["d"].ToString();
                string ad = TempData["e"].ToString();

                ViewBag.f = nm;
                ViewBag.g = mil;
                ViewBag.h = mbl;
                ViewBag.i = bg;
                ViewBag.j = ad;
                TempData.Keep();
            }

            return View();
        }

        [HttpPost]
        public ActionResult AprStaReqDon(Registration model)
        {
            try
            {

                Donor R = db.Donors.Where(x => x.Donor_Email == model.Email).FirstOrDefault();
                if (R != null)
                {
                    DonApprovalStatus e = db.DonApprovalStatuses.Where(x => x.Donr_Email == model.Email).FirstOrDefault();

                    if (e == null)
                    {
                        ViewBag.s = "Request is yet to approve";
                    }
                    else
                    {
                        var status = e.Don_Approval_status;
                        ViewBag.s = status;

                    }

                }
                else
                {
                    ViewBag.s = "No Pending requests";
                }


                return View();
            }
            catch
            {
                return View();
            }

        }



        public ActionResult ContactUs(ContactUs contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ContactUs.Add(contact);
                    db.SaveChanges();

                    ViewBag.msg = "Query submitted succesfully";
                    return View();
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

        [HttpGet]
        public ActionResult ProfDetails()
        {
            if (TempData["d"] != null)
            {
                string name = TempData["a"].ToString();
                string mail = TempData["b"].ToString();
                string mobile = TempData["c"].ToString();
                string bloodgroup = TempData["d"].ToString();
                string address = TempData["e"].ToString();
                string Gender = TempData["f"].ToString();
                string Height = TempData["g"].ToString();
                string Weight = TempData["i"].ToString();
                string Password = TempData["h"].ToString();
                string Age = TempData["j"].ToString();


                ViewBag.f = name;
                ViewBag.g = mail;
                ViewBag.h = mobile;
                ViewBag.i = bloodgroup;
                ViewBag.j = address;
                ViewBag.k = Gender;
                ViewBag.l = Height;
                ViewBag.m = Weight;
                ViewBag.n = Password;
                ViewBag.o = Age;
                TempData.Keep();
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit()
        {
            if (TempData["d"] != null)
            {
                string name = TempData["a"].ToString();
                string mail = TempData["b"].ToString();
                string mobile = TempData["c"].ToString();
                string bloodgroup = TempData["d"].ToString();
                string address = TempData["e"].ToString();
                string Gender = TempData["f"].ToString();
                string Height = TempData["g"].ToString();
                string Weight = TempData["i"].ToString();
                string Password = TempData["h"].ToString();
                string Age = TempData["j"].ToString();
                string id = TempData["k"].ToString();


                ViewBag.f = name;
                ViewBag.g = mail;
                ViewBag.h = mobile;
                ViewBag.i = bloodgroup;
                ViewBag.j = address;
                ViewBag.k = Gender;
                ViewBag.l = Height;
                ViewBag.m = Weight;
                ViewBag.n = Password;
                ViewBag.o = Age;
                ViewBag.p = id;
                TempData.Keep();
            }

            return View();
        }
        [HttpPost]
        public ActionResult Edit(Registration model)
        {
            try
            {
                string Password = TempData["h"].ToString();
                if (model.Password == Password)
                {
                    var row = db.Registrations.Where(x => x.Id == model.Id).FirstOrDefault();
                    row.Name = model.Name; row.Email = model.Email; row.Mobile = model.Mobile; row.BloodGroup = model.BloodGroup; row.Address = model.Address; row.Age = model.Age; row.Weight = model.Weight; row.Height = model.Height; row.Gender = model.Gender; row.Password = model.Password; row.CPassword = model.CPassword;
                    db.Entry(row).State = EntityState.Modified;
                    db.SaveChanges();

                }
                else
                {
                    var row = db.Registrations.Where(x => x.Id == model.Id).FirstOrDefault();
                    row.Name = model.Name; row.Email = model.Email; row.Mobile = model.Mobile; row.BloodGroup = model.BloodGroup; row.Address = model.Address; row.Age = model.Age; row.Weight = model.Weight; row.Height = model.Height; row.Gender = model.Gender; row.Password = model.Password; row.CPassword = model.CPassword;
                    row.Password = Encryption.encode(row.Password);
                    row.CPassword = Encryption.encode(row.CPassword);
                    db.Entry(row).State = EntityState.Modified;
                    db.SaveChanges();
                }


                ViewBag.Mes = "Your details are Added Succesfully kindly Please logout and login again";
                return View();
            }
            catch
            {
                return View();
            }

        }

    }
}