using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BloodProject.Models;
using BloodProject.Security;

namespace BloodProject.Controllers
{
    public class MainController : Controller
    {
        // GET: Main

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Registration model)
        {
            try
            {
                string decodeString = Encryption.encode(model.Password);
                using (var context = new BloodsDatabaseEntities())
                {
                    bool isValid = context.Registrations.Any(x => x.Email == model.Email && x.Password == decodeString);
                    if (isValid)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        Registration r = context.Registrations.Where(x => x.Email == model.Email).FirstOrDefault();

                        TempData["a"] = r.Name;
                        TempData["b"] = r.Email;
                        TempData["c"] = r.Mobile;
                        TempData["d"] = r.BloodGroup;
                        TempData["e"] = r.Address;
                        TempData["f"] = r.Gender;
                        TempData["g"] = r.Height;
                        TempData["h"] = r.Password;
                        TempData["i"] = r.Weight;
                        TempData["j"] = r.Age;
                        TempData["k"] = r.Id;
                        return RedirectToAction("UserMainPage", "UserPage");//HERE WE CAN CHANGE INTO ADMIN OR USER LOGIN PAGE
                    }
                    ModelState.AddModelError("", "Invalid Email Or Password");

                    return View();
                }
            }
            catch
            {
                return View();
            }


        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Registration reg)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    reg.Password = Encryption.encode(reg.Password);
                    reg.CPassword = Encryption.encode(reg.CPassword);
                    using (var context = new BloodsDatabaseEntities())
                    {
                        if (context.Registrations.Any(x => x.Email == reg.Email))
                        {
                            ViewBag.Msg = "This account has already existed";
                            return View();
                        }
                        else
                        {
                            context.Registrations.Add(reg);
                            context.SaveChanges();
                            ViewBag.Msg = "You are registred Successfully";


                            return View();

                        }
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

        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }

        }
    }
}