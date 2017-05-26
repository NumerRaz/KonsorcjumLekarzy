using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonsorcjumLekarzy.Database.Model;
using KonsorcjumLekarzy.Database.Repository;
using KonsorcjumLekarzy.Services;
using System.Data;
using KonsorcjumLekarzy.Infrastucture;

namespace KonsorcjumLekarzy.Areas.Administration.Controllers
{
    [Authorize]
    public class SpecializationController : Controller
    {
        private readonly IGenericService<Specialization> specializationService;
  
        public SpecializationController(IGenericService<Specialization> specializationService)
        {
            this.specializationService = specializationService;
        }

        public ActionResult Details(int ID)
        {
            return View(specializationService.ShowEntity(ID));
        }

        public ActionResult Index()
        {
            return View(specializationService.EntietiesList());
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Specialization doctorSpecialization)
        {
            if (ModelState.IsValid)
            {
                specializationService.CreateEntity(doctorSpecialization);
                return RedirectToAction("Index");
            }
            else
                return View(doctorSpecialization);
        }
        
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            return View(specializationService.ShowEntity(ID));
        }
        
        [HttpPost]
        public ActionResult Edit(Specialization doctorSpecialization)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    specializationService.UpdateEntity(doctorSpecialization);
                    return RedirectToAction("Index");
                }
                else
                    return View(doctorSpecialization);
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try Again");
            }
            return View(doctorSpecialization);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            Specialization doctorSpecialization = specializationService.ShowEntity(ID);
            if (doctorSpecialization == null)
                return RedirectToAction("Index");
            else
                return View(doctorSpecialization);
        }

        [HttpPost]
        public ActionResult Delete(int ID, string confirmButton)
        {
            Specialization doctorSpecialization = specializationService.ShowEntity(ID);
            if (doctorSpecialization == null)
                return RedirectToAction("Index");

            specializationService.DeleteEntity(ID);
            return RedirectToAction("Index");
        }
    }
}
