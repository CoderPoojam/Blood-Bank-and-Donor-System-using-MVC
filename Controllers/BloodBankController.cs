using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodProject.Controllers
{
    public class BloodBankController : Controller
    {
        // GET: Layout
        public ActionResult BBLayout()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
    }
}

