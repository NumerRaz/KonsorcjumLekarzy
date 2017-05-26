using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonsorcjumLekarzy.Areas.Administration.Models;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Services;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    [Authorize]
    public class VisitController : Controller
    {
        private readonly IGenericService<Visit> visitService;
        private readonly IGenericService<Doctor> doctorService;
        private readonly IGenericService<Patient> patientService;

        public VisitController(IGenericService<Visit> visitService, IGenericService<Doctor> doctorService, IGenericService<Patient> patientService)
        {
            this.visitService = visitService;
            this.doctorService = doctorService;
            this.patientService = patientService;
        }

        public ActionResult Index()
        {
            return View(visitService.EntietiesList());
        }

        public ActionResult Details(int ID)
        {
            return View(visitService.ShowEntity(ID));
        }

        [HttpGet]
        public ActionResult Create()
        {
            var vm = new VisitVM
            {
                Doctors = doctorService.EntietiesList().ToList(),
                Patients = patientService.EntietiesList().ToList()
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Create(Visit visit)
        {
            if (ModelState.IsValid)
            {
                visitService.CreateEntity(visit);
                return RedirectToAction("Index");
            }
            else
                return View(visit);
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(visitService.ShowEntity(ID));
        }

        [HttpPost]
        public ActionResult Edit(Visit visit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    visitService.UpdateEntity(visit);
                    return RedirectToAction("Index");
                }
                else
                    return View(visit);
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try Again");
            }
            return View(visit);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Visit doctorSpecialization = visitService.ShowEntity(ID);
            if (doctorSpecialization == null)
                return RedirectToAction("Index");
            else
                return View(doctorSpecialization);
        }

        [HttpPost]
        public ActionResult Delete(int ID, string confirmButton)
        {
            Visit doctorSpecialization = visitService.ShowEntity(ID);
            if (doctorSpecialization == null)
                return RedirectToAction("Index");
            visitService.DeleteEntity(ID);
            return RedirectToAction("Index");
        }
    }
}
