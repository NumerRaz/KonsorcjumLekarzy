using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    public class DocotrsController : Controller
    {
        private readonly IGenericService<Doctor> doctorService;

        public DocotrsController(IGenericService<Doctor> doctorService)
        {
            this.doctorService = doctorService;
        }


        public ActionResult Details(int ID)
        {
            return View(doctorService.ShowEntity(ID));
        }


        public ActionResult Index()
        {
            return View(doctorService.EntietiesList());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                doctorService.CreateEntity(doctor);
                return RedirectToAction("Index");
            }
            else
                return View(doctor);
        }


        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(doctorService.ShowEntity(ID));
        }

    
        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    doctorService.UpdateEntity(doctor);
                    return RedirectToAction("Index");
                }
                else
                    return View(doctor);
            }
            catch(DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try Again");
            }
            return View(doctor);
        }

        //TO DO:
        //Delete nie działa... Problem jest najprawdopodobniej z kluczami.


        /*
        [HttpGet]
        public ActionResult Delete(bool? saveChangesError = false, int ID = 0)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Doctor doctor = doctorService.ShowEntity(ID);
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Doctor doctor)
        {
            try
            {
                Doctor doctorToDelete = doctorService.ShowEntity(doctor.UserId);
                doctorService.DeleteEntity(doctorToDelete);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { doctor = doctor, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
        */
    }
}
