using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BloodProject.Models;
namespace BloodProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BloodsDatabaseEntities db = new BloodsDatabaseEntities();
        public ActionResult Index()
        {
            db.Admins.ToList();
            db.BloodStocks.ToList();
            db.Donors.ToList();
            db.Registrations.ToList();
            db.Requesters.ToList();
            return View();
        }
    }
}