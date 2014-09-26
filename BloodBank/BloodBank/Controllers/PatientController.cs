using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBank.Controllers
{
    public class PatientController : Controller
    {
        //create a connection to the database
        Models.BloodBanksEntities db = new Models.BloodBanksEntities();


        //
        // GET: /Patient/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new Models.Patient());
        }

        [HttpPost]
        public ActionResult Add(Models.Patient patient)
        {
           
            //add our patient info to the database
            db.Patients.Add(patient);
            db.SaveChanges();
            //kick the user to the thank you page
            return RedirectToAction("ThankYou", "Patient");
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult CurrentPatients()
        {
            //list the current patients
            return View(db.Patients);
        }

        public ActionResult Details(int id)
        {
            return View(db.Patients.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Patients.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.Patient patient)
        {
            db.Entry(patient).State = System.Data.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("CurrentPatients", "Patient");
        }

        public ActionResult Delete(int id)
        {
            return View(db.Patients.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            Models.Patient patientToDelete = db.Patients.Find(id);
            db.Patients.Remove(patientToDelete);
            db.SaveChanges();
            return RedirectToAction("CurrentPatients", "Patient");
        }
    }
}
