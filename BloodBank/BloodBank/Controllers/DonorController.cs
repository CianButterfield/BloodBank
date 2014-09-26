using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class DonorController : Controller
    {

        Models.BloodBanksEntities db = new Models.BloodBanksEntities();


        //
        // GET: /Donor/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Models.Donor());
        }

        [HttpPost]
        public ActionResult Add(Models.Donor donor)
        {
            
            //add our donor info to the database
            db.Donors.Add(donor);
            db.SaveChanges();
            //kick the user to the thank you page
            return RedirectToAction("ThankYou", "Donor");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult CurrentDonors()
        {
            return View(db.Donors);
        }

        public ActionResult Details(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Donors.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.Donor donor)
        {
            db.Entry(donor).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CurrentDonors", "Donor");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Donors.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            Models.Donor donorToDelete = db.Donors.Find(id);
            db.Donors.Remove(donorToDelete);
            db.SaveChanges();
            return RedirectToAction("CurrentDonors", "Donor");
        }
    }
}
